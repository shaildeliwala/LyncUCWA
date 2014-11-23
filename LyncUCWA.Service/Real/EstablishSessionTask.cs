using LyncUCWA.Service.Interface;
using LyncUCWA.Service.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Real
{
    public class EstablishSessionTask : BaseEstablishSessionTask
    {
        public override async Task InitiateSession(string userId, string password, string oauthToken = "")
        {
            var response = await AutoDiscover(userId);
            var userResponse = await FollowUser(response._links.user.href, oauthToken.IsEmpty() ? String.Empty : oauthToken);

            if (userResponse.Response.StatusCode == HttpStatusCode.Unauthorized)
            {
                IEnumerable<string> authItems;
                if (!userResponse.Response.Headers.TryGetValues("WWW-Authenticate", out authItems))
                    return;
                var authenticateResponse = await Authenticate(authItems, userId, password);
                if (authenticateResponse != null && authenticateResponse.Response.StatusCode == HttpStatusCode.OK)
                {
                    Configuration.Instance().OAuthToken = JToken.Parse(await authenticateResponse.Response.Content.ReadAsStringAsync()).SelectToken("access_token").ToString();
                    userResponse = await FollowUser(response._links.user.href, Configuration.Instance().OAuthToken);
                }
            }
            if (userResponse.Response.StatusCode != HttpStatusCode.OK)
                return;
            var applicationsLink = (string)JObject.Parse(await userResponse.Response.Content.ReadAsStringAsync()).SelectToken("_links.applications.href");
            if (applicationsLink.IsEmpty())
                return;
            var applicationResponse = await FollowApplications(applicationsLink);
            if (applicationResponse.Response.StatusCode == HttpStatusCode.Created)
            {
                Configuration.Instance().CurrentApplication = applicationResponse;
                OnSessionEstablished();
            }
        }

        protected override async Task<AutoDiscoverModel> AutoDiscover(string userId)
        {
            var uri = String.Concat(
                Configuration.Instance().LyncServerUri, "?sipuri=sip:", WebUtility.UrlEncode(userId));
            return await ServiceCallManager.SendData<AutoDiscoverModel>(uri);
        }

        protected override async Task<BaseModel> FollowUser(string userUrl, string oauthToken = "")
        {
            if (!oauthToken.IsEmpty())
            {
                var url = new Uri(userUrl);
                Configuration.Instance().DomainAddress = new Uri(url.AbsoluteUri.Replace(url.PathAndQuery, String.Empty));
                Configuration.Instance().OAuthToken = oauthToken;
            }
            return await ServiceCallManager.SendData<BaseModel>(userUrl);
        }

        protected override async Task<BaseModel> Authenticate(IEnumerable<string> authItems, string userId, string password)
        {
            string oauthProviderLink = String.Empty, payload = String.Empty;
            var authHeaderItems = authItems.FirstOrDefault(a => a.ToLower().Contains("msrtcoauth"));
            if (authHeaderItems == null)
                return null;

            authItems = authHeaderItems.Split(new char[] { ' ', ',' });

            // Get OAuth provider link from the above items
            oauthProviderLink = authItems.FirstOrDefault(c => c.Contains("href")).Replace("href=", String.Empty).Trim('"').Trim();

            // Get allowed authentication types. Combination of: password, windows, passive, anonmeeting
            var allowedAuthMethods = authItems.First(c => c.Contains("grant_type")).Replace("grant_type", "").Split(',');

            // TODO "sip"
            // This application uses the password grant type. Others may be defined and used as required.
            payload = String.Concat("grant_type=password&username="/*, sipped ? "sip:" : String.Empty*/, userId, "&password=", password);
            return await ServiceCallManager.SendData<BaseModel>(oauthProviderLink, HttpMethod.Post, new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded"));
        }

        protected override async Task<ApplicationModel> FollowApplications(string applicationUrl)
        {
            var payload = JsonConvert.SerializeObject(new { UserAgent = "UCWA", EndpointId = Guid.NewGuid().ToString(), Culture = "en-US" });
            return await ServiceCallManager.SendData<ApplicationModel>(applicationUrl, HttpMethod.Post, new StringContent(payload, Encoding.UTF8, "application/json"));
        }
    }
}
