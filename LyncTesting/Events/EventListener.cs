using LyncTest.JsonResponses;
using LyncTest.Properties;
using LyncTest.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using LyncTest.Helpers;

namespace LyncTest.Events
{
    public static class EventListener
    {
        private static Timer samayeSamaye = new Timer() { Interval = 1000 };
        private static string nextLink;
        private static LyncHttpClient lyncClient;

        private static Dictionary<EventNames, Func<EventDetails, Task>> eventDictionary = 
            new Dictionary<EventNames, Func<EventDetails, Task>>();

        private static Queue<KeyValuePair<EventDetails, string>> eventQueue = 
            new Queue<KeyValuePair<EventDetails, string>>();

        /// <summary>
        /// Just a placeholder subroutine created for sake of clarity
        /// </summary>
        internal static void StartListening() { }

        private enum EventNames
        {
            MessagingInvitationReceived = 1        
        }

        static EventListener()
        {
            lyncClient = new LyncHttpClient() { Timeout = TimeSpan.FromMinutes(15.0d) };
            InitializeDictionary();
            nextLink = Program.ApplicationInstance._links.events.href;
            samayeSamaye.Tick += samayeSamaye_Tick;
            samayeSamaye.Start();
            GetEvents();
        }

        static async void samayeSamaye_Tick(object sender, EventArgs e)
        {
            samayeSamaye.Stop();
            await MiscellaneousTasks.ReportMyActivity();

            while (eventQueue.Count > 0)
            {
                var dequeue = eventQueue.Dequeue();
                await ProcessLastResponse(dequeue);
            }
            samayeSamaye.Start();
        }
    
        private static void InitializeDictionary()
        {
            //eventDictionary.Add(EventNames.MessagingInvitationReceived, PromptIncomingMessage);
        }

        internal static async void GetEvents()
        {
            ResponseForm responseForm = null;

            while (true)
            {
                //http://stackoverflow.com/questions/1434451/what-does-connection-reset-by-peer-mean
                //http://technet.microsoft.com/en-us/library/cc957018.aspx
                //http://msdn.microsoft.com/en-us/library/office/dn323631(v=office.15).aspx (Timeout problem solution)
                HttpResponseMessage httpResponse = null;
                try
                {
                    httpResponse = await lyncClient.GetAsync(nextLink);
                }
                catch (Exception)
                { }

                if (httpResponse == null) continue;
                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    responseForm = responseForm ?? new ResponseForm();
                    responseForm.txtResponseContent.AppendText(String.Concat(jsonResponse, Environment.NewLine, Environment.NewLine));
                    if (!responseForm.Visible) responseForm.Show();
                    var response = JsonConvert.DeserializeObject<EventDetails>(jsonResponse);
                    lock (eventQueue)
                    {
                        eventQueue.Enqueue(new KeyValuePair<EventDetails, string>(response, jsonResponse));
                    }

                    nextLink = response._links.next == null ?
                        (response._links.resync == null ?
                        Program.ApplicationInstance._links.events.href
                        : response._links.resync.href)
                        : response._links.next.href;
                }
                else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    nextLink = Program.ApplicationInstance._links.events.href;
                }
            }
        }

        private static async Task ProcessLastResponse(KeyValuePair<EventDetails,string> response)
        {
            var objResponse = JObject.Parse(response.Value);
            foreach (var sender in response.Key.sender)
            {
                if (sender.rel.ICEquals("communication"))
                {
                    var msgEvent = sender.events.Find(anEvent => anEvent.link.rel.ICEquals("messagingInvitation"));
                    if (msgEvent != null && msgEvent._embedded.messagingInvitation.direction.ICEquals("incoming"))
                    {
                        await PromptIncomingMessage(msgEvent._embedded.messagingInvitation._links.accept.href,
                            msgEvent._embedded.messagingInvitation._embedded.from.name);
                    }
                }
            }
            
            if (null != 
                (string)objResponse.
                SelectToken("sender[0].events[0]._embedded.message._links.plainMessage.href"))
                    {
                if ("incoming".ICEquals(response.Key.sender[0].events[0]._embedded.message.direction))
                        {
                            MainForm.chatBox.Text =
                             String.Concat(
                                 MainForm.chatBox.Text,
                                 Environment.NewLine,
                                 Environment.NewLine,
                                 Settings.Default.CurrentSender, ": ",
                                 getDatafromStream(response.Key.sender[0].events[0]._embedded.message._links.plainMessage.href.Replace("data:text/plain;charset=utf-8,", "")));
                        }
                    }

            if (null != 
                (string)objResponse.
                SelectToken("sender[0].events[2]._embedded.messaging._links.sendMessage.href"))
            { 
                if (Settings.Default.CurrentConvo.Trim().Length == 0)
                {
                            Settings.Default.CurrentConvo = (string)objResponse.
                                SelectToken("sender[0].events[2]._embedded.messaging._links.sendMessage.href");
                }
            }
            else if (null !=
                (string)objResponse.
                SelectToken("sender[1].events[3]._embedded.messaging._links.sendMessage.href"))
            {
                if (Settings.Default.CurrentConvo.Trim().Length == 0)
                {
                    Settings.Default.CurrentConvo = (string)objResponse.
                        SelectToken("sender[1].events[3]._embedded.messaging._links.sendMessage.href");
                }
            }
        }

        private static async Task PromptIncomingMessage(string link, string messageSender)
        {
            await lyncClient.PostAsync(link, new StringContent(String.Empty));
            Settings.Default.CurrentSender = messageSender;
        }
            //if (MessageBox.Show((IWin32Window) Control.FromHandle(Program.mForm.Handle),
            //    string.Concat("Accept message from ",
            //                  details.sender[0].events[0]._embedded.messagingInvitation._embedded.from.name,"?",
            //                  System.Environment.NewLine,
            //                  getDatafromStream(details.sender[0].events[0]._embedded.messagingInvitation._links.message.href.Replace("data:text/plain;charset=utf-8,", ""))))
            //    == DialogResult.OK)
            //{
            //    await lyncClient.PostAsync(details.sender[0].events[0]._embedded.messagingInvitation._links.accept.href,new System.Net.Http.StringContent(""));
            //}
            //else
            //{
            //    await lyncClient.PostAsync(details.sender[0].events[0]._embedded.messagingInvitation._links.decline.href, new System.Net.Http.StringContent(""));
            //}

        private static string getDatafromStream(string text)
        {
            var baha = HttpUtility.UrlDecode(text, Encoding.UTF8);
            return baha;
        }

    }   
}