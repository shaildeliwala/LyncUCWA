using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace LyncTest
{
    internal static class MiscellaneousTasks
    {
        internal async static Task GetContacts()
        {
            var response = JsonConvert.DeserializeObject<JsonResponses.MyContacts> (
                await (new LyncHttpClient()).
                GetStringAsync(Program.ApplicationResource._embedded.people._links.myContacts.href));
            
            foreach (JsonResponses.Contact person in response._embedded.contact)
            {
                var presence = (string)JObject.Parse(json:(await (new LyncHttpClient()).
                    GetStringAsync(person._links.contactPresence.href))).
                    SelectToken("availability");
                LyncTest.UI.MainForm.gridReference.Rows.Add(person.name, person.emailAddresses[0], presence); 
            }
        }

        internal async static Task MakeMeAvailable()
        {
            var payload = new JsonRequests.MakeMeAvailablePayload(
                status: "Online",
                modalities: new System.Collections.Generic.List<string>() { "Messaging" });
            
            UI.MainForm.statusLabel.Text = "Online";

            await (new LyncHttpClient()).PostAsync(
                requestUri: Program.ApplicationResource._embedded.me._links.makeMeAvailable.href,
                content: new StringContent(
                    content: JsonConvert.SerializeObject(payload, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }),
                    encoding: System.Text.Encoding.UTF8,
                    mediaType: "application/json"));
        }
    }
}
