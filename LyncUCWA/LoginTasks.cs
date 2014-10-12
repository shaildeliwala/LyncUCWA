using LyncUCWA.JsonRequests;
using LyncUCWA.JsonResponses;
using LyncUCWA.Properties;
using LyncUCWA.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;   
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace LyncUCWA
{
    /* Notes: 
   * 1) The multitude of Try-Catch blocks can be transferred to a shared async function in order to reduce the number of lines of code.
   * 2) Multi-line comment notation is used to describe behaviour yet to be implemented.
   * 3) Return points need to be specified clearly as sometimes null
   */
    public static class LoginTasks
    {
        internal static string UserID;
        internal static string Password;
        internal static HttpResponseMessage response = new HttpResponseMessage();
        internal static HttpClient httpClient = new HttpClient();
        internal static LyncHttpClient LyncHttpClient;
        private static string nl = Environment.NewLine;
        private static TextBox il = MainForm.loginActivityIndicator;

        private static void AddCurrentLoginStatus(this TextBox txt, string s)
        {
            txt.AppendText(String.Concat(DateTime.Now.ToLongTimeString(), ": ", s, nl, nl));
        }

        public static async Task<HttpResponseMessage> AutoDiscover()
        {
            /* UNCOMMENT LATER:
             * 
                      //First try internal discovery : change hardcoded values
                      request = new LyncHttpRequest(new System.Uri("https://lyncdiscoverinternal." +
                                                                             "gotuc.net/?sipuri=sip:" + UserID), HttpMethod.GET);
                      try
                      {
                          response = (HttpWebResponse)(await request.HttpRequest.GetResponseAsync());
                          if (null != response && HttpStatusCode.OK == response.StatusCode) { return response; }
                      }
                      catch (WebException ex)
                      {
                          System.Console.Write("Internal requests failed. Trying external requests... \n\n");
                      }
             * 
             */
            //If internal fails, try external : change hardcoded values

            try
            {
                il.AddCurrentLoginStatus("Attempting AutoDiscover...");
                response = await httpClient.GetAsync(new Uri(
                    String.Concat(Configuration.Instance().LyncServerUri.ToString(), "?sipuri=sip:", HttpUtility.UrlEncode(UserID))));
                if (null != response && HttpStatusCode.OK == response.StatusCode)
                {
                    il.AddCurrentLoginStatus("External login succeeded. Server sent a link to the User resource as expected.");
                    return response;
                }
            }
            catch (Exception ex)
            {
                il.AddCurrentLoginStatus(String.Format("External requests failed. Reason: {0}\n{1} \n", ex.HResult.ToString(), ex.Message.ToString()));
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }



        public static async Task<HttpResponseMessage> FollowUser(Uri userUrl)
        {
            il.AddCurrentLoginStatus("Attempting to GET User resource...");
            try
            {
                if (0 != Settings.Default.OAuthToken.Trim().Length)
                {
                    il.AddCurrentLoginStatus("OAuth token is available; attempting request with Authorization HTTP header attached...");
                    Settings.Default.DomainAddress = userUrl.AbsoluteUri.Replace(userUrl.PathAndQuery, String.Empty);
                    LyncHttpClient = new LyncHttpClient();
                    return await LyncHttpClient.GetAsync(userUrl);
                }
                else
                {
                    il.AddCurrentLoginStatus("OAuth token was not found; attempting request without Authorization header...");
                    return await httpClient.GetAsync(userUrl);
                }
            }
            catch (Exception ex)
            {
                il.AddCurrentLoginStatus(String.Format("Failed this time. Status Code: {0}\nMessage: {1}\n", response.StatusCode.ToString(), ex.Message.ToString()));
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static async Task<HttpResponseMessage> DoAuthentication(HttpResponseMessage userResponse, bool sipped = false)
        {
            // See: http://ucwa.lync.com/documentation/GettingStarted-Authentication)

            // Get WWW-Authenticate Header items
            il.AddCurrentLoginStatus("Getting WWW-Authenticate Header items...");
            IEnumerable<string> authItems;
            string oauthProviderLink = String.Empty, payload = String.Empty;
            var authHeaderItems = userResponse.Headers.TryGetValues("WWW-Authenticate", out authItems) ? authItems.First(a => a.ToLower().Contains("msrtcoauth")) : null;
            if (null != authHeaderItems)
            {
                authItems = authHeaderItems.Split(new char[] { ' ', ',' });

                // Get OAuth provider link from the above items
                oauthProviderLink = authItems.FirstOrDefault(c => c.Contains("href")).Replace("href=", String.Empty).Trim('"').Trim();

                // Get allowed authentication types. Combination of: password, windows, passive, anonmeeting
                var allowedAuthMethods = authItems.First(c => c.Contains("grant_type")).Replace("grant_type", "").Split(',');

                // This application uses the password grant type. Others may be defined and used as required.
                payload = String.Concat("grant_type=password&username=", sipped ? "sip:" : String.Empty, UserID, "&password=", Password);
            }

            /* Proper return behaviour yet to be defined below. */
            try
            {
                il.AddCurrentLoginStatus("Sending POST request to the OAuth provider to get an OAuth token for this session...");
                response = await httpClient.PostAsync(oauthProviderLink, new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (null != response && HttpStatusCode.OK == response.StatusCode)
                {
                    il.AddCurrentLoginStatus("Request was successful. Extracting OAuth token from response content...");
                    Settings.Default.OAuthToken = JToken.Parse(await response.Content.ReadAsStringAsync()).SelectToken("access_token").ToString();
                    return response;
                }
            }
            catch (Exception ex)
            {
                il.AddCurrentLoginStatus(String.Format("Authentication procedure threw an exception: {0}", ex.Message.ToString()));
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static async Task<HttpResponseMessage> FollowApplications()
        {
            il.AddCurrentLoginStatus("Making a  POST request to the Application resource to get an Application instance for this session...");

            var payload = JsonConvert.SerializeObject(new Applications("Lync UCWA", Guid.NewGuid().ToString()));
            try
            {
                response = await LyncHttpClient.PostAsync(
                    requestUri: Settings.Default.ApplicationsLink,
                    content: new StringContent(payload, Encoding.UTF8, "application/json"));
                if (null != response && HttpStatusCode.Created == response.StatusCode) { return response; }
            }
            catch (WebException ex)
            {
                il.AddCurrentLoginStatus(String.Format("Following applications link failed. Error: {0}", ex.Message.ToString()));
                return response;
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static async Task DoLoginTasks()
        {
            il.AddCurrentLoginStatus("Login started...");
            var loginResponse = await LoginTasks.AutoDiscover();
            /* If response contains redirects, handle here or implement recursion on AttemptLogin() */
            var userUrl = JsonConvert.DeserializeObject<AutoDiscoverJson>(await loginResponse.Content.ReadAsStringAsync())._links.user.href;
            var userResponse = await FollowUser(new Uri(userUrl));
            HttpResponseMessage authenticateResponse;
            HttpResponseMessage applicationsResponse;

            if (HttpStatusCode.Unauthorized == userResponse.StatusCode)
            {
                authenticateResponse = await DoAuthentication(userResponse);
                // Follow user resource again now that there's an available OAuth token
                userResponse = await FollowUser(new Uri(userUrl));
            }

            /* Add redirect (HTTP 500 response) handling code */

            if (HttpStatusCode.OK == userResponse.StatusCode)
            {
                il.AddCurrentLoginStatus("Authentication successful. Following applications link to get application resource...");
                Settings.Default.ApplicationsLink = (string)JObject.Parse(new StreamReader(await userResponse.Content.ReadAsStreamAsync()).ReadToEnd()).SelectToken("_links.applications.href");
                applicationsResponse = await LoginTasks.FollowApplications();
                if (HttpStatusCode.Created == applicationsResponse.StatusCode)
                {
                    LyncHttpClient.IsLoggedIn = true;
                    il.AddCurrentLoginStatus("Successfully received an Application instance. Beginning current session...");
                    MainForm.applicationObject.Text = await applicationsResponse.Content.ReadAsStringAsync();
                    Program.ApplicationInstance = new ApplicationResponse();
                    Program.ApplicationInstance = JsonConvert.DeserializeObject<ApplicationResponse>(await applicationsResponse.Content.ReadAsStringAsync());
                    MainForm.nameLabel.Text = Program.ApplicationInstance._embedded.me.name;
                }
            }
            else
            {
                il.AddCurrentLoginStatus("Login failed.");
            }
        }
    }
}