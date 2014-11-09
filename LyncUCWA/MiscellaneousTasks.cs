using LyncUCWA.Service;
using LyncUCWA.JsonResponses;
using LyncUCWA.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LyncUCWA
{
    internal static class MiscellaneousTasks
    {
        internal async static Task ReportMyActivity()
        {
            if (!Uri.IsWellFormedUriString(Settings.Default.reportMyActivityLink, UriKind.RelativeOrAbsolute)
                || Settings.Default.reportMyActivityLink.IsEmpty())
            {
                Program.ApplicationInstance._embedded.me._links.reportMyActivity = Program.ApplicationInstance._embedded.me._links.reportMyActivity ?? new ClsHref();
                if (!Uri.IsWellFormedUriString(Program.ApplicationInstance._embedded.me._links.reportMyActivity.href, UriKind.RelativeOrAbsolute)
                    || Program.ApplicationInstance._embedded.me._links.reportMyActivity.href.IsEmpty())
                {
                    var response = await (new LyncHttpClient()).GetStringAsync(Program.ApplicationInstance._embedded.me._links.self.href);
                    Program.ApplicationInstance._embedded.me._links.reportMyActivity.href = (string)(JObject.Parse(response)).SelectToken("_links.reportMyActivity.href");
                }
                Settings.Default.reportMyActivityLink = Program.ApplicationInstance._embedded.me._links.reportMyActivity.href;
            }
            
            var resp = await (new LyncHttpClient()).PostAsync(Settings.Default.reportMyActivityLink, new StringContent(String.Empty));
            resp.ToString();
        }
    }
}