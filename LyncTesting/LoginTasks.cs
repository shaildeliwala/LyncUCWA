using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;

namespace LyncTest
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
                response = await httpClient.GetAsync(new System.Uri("https://lyncdiscover." +
                                                                   "gotuc.net/?sipuri=sip:" + UserID));
                if (null != response && HttpStatusCode.OK == response.StatusCode)
                {
                    Console.Write("External login succeeded. \n\n");
                    return response;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write("External requests failed. Reason: {0}\n{1} \n", ex.HResult.ToString(),ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static async Task<HttpResponseMessage> FollowUser(Uri userUrl)
        {
            try
            {
                if (0 != Properties.Settings.Default.OAuthToken.Trim().Length)
                {
                    LyncHttpClient = new LyncHttpClient();
                    return await LyncHttpClient.GetAsync(userUrl);
                }
                else
                {
                    return await httpClient.GetAsync(userUrl);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Failed this time. Status Code: {0}\nMessage: {1}\n", response.StatusCode.ToString(),ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static async Task<HttpResponseMessage> DoAuthentication(HttpResponseMessage userResponse)
        {
            // See: http://ucwa.lync.com/documentation/GettingStarted-Authentication)

            // Get WWW-Authenticate Header items
            var authHeaderItems = userResponse.Headers.GetValues("WWW-Authenticate").First(a => a.ToLower().Contains("msrtcoauth")).Split(new char[] { ' ', ',' });

            // Get OAuth provider link from the above items
            var oauthProviderLink = authHeaderItems.First(c => c.Contains("href")).Replace("href=", "").Trim('"').Trim(); //get oauth provider link

            // Get allowed authentication types. Combination of: password, windows, passive, anonmeeting
            var allowedAuthMethods = authHeaderItems.First(c => c.Contains("grant_type")).Replace("grant_type", "").Split(',');

            // This application uses the password grant type. Others may be defined and used as required.
            var payload = string.Concat("grant_type=password&username=sip:", UserID, "&password=", Password);
           
            /* Proper return behaviour yet to be defined below. */
            try
            {
                response = await httpClient.PostAsync(oauthProviderLink, new StringContent(payload));
                if (null != response && HttpStatusCode.OK == response.StatusCode) { return response; }
            }
            catch (Exception ex)
            {
                Console.Write("Authentication failed because: {0}", ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static async Task<HttpResponseMessage> FollowApplications()
        {
            var payload = JsonConvert.SerializeObject(new JsonRequests.Applications("UCWA Samples", Guid.NewGuid().ToString()));
            
            try
            {
                response = await LyncHttpClient.PostAsync(
                    requestUri: Properties.Settings.Default.ApplicationsLink, 
                    content: new StringContent(payload,System.Text.Encoding.UTF8,"application/json"));
                if (null != response && HttpStatusCode.Created == response.StatusCode){ return response; }
            }
            catch (WebException ex)
            {
                Console.Write("Following applications link failed. Error: {0}", ex.Message.ToString());
                return response;
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static async Task DoLoginTasks()
        {
            Console.Write(DateTime.Now + " Login started...\n\n");
            var loginResponse = await LoginTasks.AutoDiscover();
            /* If response contains redirects, handle here or implement recursion on AttemptLogin() */
            var userUrl = JsonConvert.DeserializeObject<JsonResponses.AutoDiscoverJson>((new StreamReader(await loginResponse.Content.ReadAsStreamAsync()).ReadToEnd()))._links.user.href;
            var userResponse = await LoginTasks.FollowUser(new Uri(userUrl));
            HttpResponseMessage authenticateResponse;
            HttpResponseMessage applicationsResponse;

            if (HttpStatusCode.Unauthorized == userResponse.StatusCode)
            {
                authenticateResponse = await LoginTasks.DoAuthentication(userResponse);
                Properties.Settings.Default.OAuthToken = Properties.Settings.Default.copytoken;
                // Follow user resource again now that there's an available OAuth token
                userResponse = await LoginTasks.FollowUser(new Uri(userUrl));
            }

            /* Add redirect (HTTP 500 response) handling code */

            if (HttpStatusCode.OK == userResponse.StatusCode)
            {
                Console.Write("Authentication successful. Following applications link to get application resource... \n\n");
                Properties.Settings.Default.ApplicationsLink = (string) Newtonsoft.Json.Linq.JObject.Parse(new StreamReader(await userResponse.Content.ReadAsStreamAsync()).ReadToEnd()).SelectToken("_links.applications.href");
                applicationsResponse = await LoginTasks.FollowApplications();
                if (HttpStatusCode.Created == applicationsResponse.StatusCode)
                {
                    Program.ApplicationResource = new JsonResponses.ApplicationResponse();
                    Program.ApplicationResource = JsonConvert.DeserializeObject<JsonResponses.ApplicationResponse>(new StreamReader(await applicationsResponse.Content.ReadAsStreamAsync()).ReadToEnd());
                    UI.MainForm.nameLabel.Text = Program.ApplicationResource._embedded.me.name;
                }
            }
        }
    }
}