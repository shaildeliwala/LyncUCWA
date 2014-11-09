using LyncUCWA.Service;
using LyncUCWA.JsonRequests;
using LyncUCWA.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LyncUCWA.PhoneAudio
{
    public class CallTasks
    {
        public static async Task Call(string phoneNumber, string to)
        {
            MainForm.callLabel.Text = "Attempting call...";
            if (Program.ApplicationInstance._embedded.communication._links.startPhoneAudio == null) return;
            if (Program.ApplicationInstance._embedded.communication._links.startPhoneAudio.href.IsEmpty())
            {
                var response = await (new LyncHttpClient()).PutAsync(
                    Program.ApplicationInstance._embedded.communication._links.self.href, new StringContent(""));
                if (response.IsSuccessStatusCode)
                {
                    Program.ApplicationInstance._embedded.communication._links.startPhoneAudio.href =
                        (string)(JObject.Parse(await response.Content.ReadAsStringAsync())).SelectToken("_links.startPhoneAudio.href");
                }
                else
                {
                    
                    MainForm.callLabel.Text = "Failed";
                    return;
                }
            }
            var lyncClient = new LyncHttpClient();
            var lyncResponse = await lyncClient.PostAsync(Program.ApplicationInstance._embedded.communication._links.startPhoneAudio.href,
                new StringContent(
                await Task.Run<string>(delegate
                {
                    return JsonConvert.SerializeObject(new StartPhoneAudioPayload()
                        {
                            //Fill these values
                            Importance = "Normal",
                            OperationId = Guid.NewGuid().ToString(),
                            PhoneNumber = phoneNumber,
                            Subject = "We want to see that what we think should work actually works.",
                            ThreadId = Guid.NewGuid().ToString(),
                            To = String.Concat("sip:", to)
                        });
                }), Encoding.UTF8, "application/json"));
            lyncResponse.ToString();
        }
    }
}