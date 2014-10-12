using LyncUCWA.Helpers;
using LyncUCWA.JsonRequests;
using LyncUCWA.JsonResponses;
using LyncUCWA.Properties;
using LyncUCWA.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LyncUCWA
{
    internal static class MiscellaneousTasks
    {
        internal async static Task MakeMeAvailable()
        {
            var payload = new MakeMeAvailablePayload(
                status: "Online",
                modalities: new List<string>() { "Messaging", "PhoneAudio" });
            
            MainForm.statusLabel.Text = "Online";

            var response = await (new LyncHttpClient()).PostAsync(
                requestUri: Program.ApplicationInstance._embedded.me._links.makeMeAvailable.href,
                content: new StringContent(
                    content: JsonConvert.SerializeObject(payload, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json"));
        }

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