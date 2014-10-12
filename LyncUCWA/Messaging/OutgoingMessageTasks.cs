using LyncUCWA.JsonRequests;
using LyncUCWA.Properties;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LyncUCWA.Messaging
{
    internal static class OutgoingMessageTasks
    {
        internal static DataGridView gridReference = (DataGridView)Program.mForm.Controls["gridFriends"];
        internal static LyncHttpClient lyncHttpClient = new LyncHttpClient();

        internal static async Task DoSendMessageTasks(UI.MainForm sender)
        {
            /* Error handling code and HTTP status message checking is yet to be implemented */
            
            var response = await PostStartMessaging();
        }

        internal static async Task<HttpResponseMessage> PostStartMessaging()
        {
            var payload = JsonConvert.SerializeObject(
                    new StartMessagingPayload("Normal",
                        Guid.NewGuid().ToString(), 
                        "Sample convo", null,
                        String.Concat("sip:", gridReference.SelectedRows[0].Cells[1].Value.ToString()),
                        Guid.NewGuid().ToString()));
            return await lyncHttpClient.PostAsync(
                    Program.ApplicationInstance._embedded.communication._links.startMessaging.href,
                    new StringContent(payload, Encoding.UTF8, "application/json"));
        }

        internal static async Task PostSendMessage(string msg)
        {
            if (HttpStatusCode.Created == (await lyncHttpClient.PostAsync(
                    Settings.Default.CurrentConvo,
                    new StringContent(msg, Encoding.UTF8, "text/plain"))).StatusCode)
            {
                UI.MainForm.chatBox.Text = String.Concat(
                       UI.MainForm.chatBox.Text,
                       Environment.NewLine,
                       Environment.NewLine,
                       UI.MainForm.nameLabel.Text, ": ", msg);
            }
        }
    }
}
