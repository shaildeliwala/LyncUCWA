using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace LyncTest.MessagingClasses
{
    internal static class OutgoingMessageTasks
    {

        internal static System.Windows.Forms.DataGridView gridReference = (System.Windows.Forms.DataGridView)Program.mForm.Controls["gridFriends"];
        internal static LyncHttpClient lyncHttpClient = new LyncHttpClient();
        internal static HttpResponseMessage response;

        internal static async Task DoSendMessageTasks(UI.MainForm sender)
        {
            /* Error handling code and HTTP status message checking is yet to be implemented */
            
            var response = await PostStartMessaging();
            var d = response;
            var t = d.GetHashCode();
        }

        internal static async Task<HttpResponseMessage> PostStartMessaging()
        {
            var payload = JsonConvert.SerializeObject(
                    new JsonRequests.StartMessagingPayload("Normal",
                        System.Guid.NewGuid().ToString(), 
                        "Sample convo", null,
                        string.Concat("sip:", gridReference.SelectedRows[0].Cells[1].Value.ToString()),
                        System.Guid.NewGuid().ToString()));
            return await lyncHttpClient.PostAsync(
                    Program.ApplicationResource._embedded.communication._links.startMessaging.href,
                    new StringContent(payload, Encoding.UTF8, "application/json"));
        }

        internal static async Task PostSendMessage(string msg)
        {
            if (System.Net.HttpStatusCode.Created == (await lyncHttpClient.PostAsync(
                    Properties.Settings.Default.CurrentConvo,
                    new StringContent(msg, Encoding.UTF8, "text/plain"))).StatusCode)
            {
                UI.MainForm.chatBox.Text = string.Concat(
                       UI.MainForm.chatBox.Text,
                       System.Environment.NewLine,
                       System.Environment.NewLine,
                       UI.MainForm.nameLabel.Text, ": ", msg);
            }
        }
    }
}
