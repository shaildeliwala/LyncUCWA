using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using Newtonsoft.Json.Linq;

namespace LyncTest
{
    public static class EventListener
    {
        private static Timer samayeSamaye = new Timer() { Interval = 1000 };
        private static string nextLink;
        private static LyncHttpClient lyncClient;

        private static Dictionary<EventNames, System.Func<JsonResponses.EventDetails, Task>> eventDictionary = 
            new Dictionary<EventNames, System.Func<JsonResponses.EventDetails, Task>>();

        private static Queue<KeyValuePair<JsonResponses.EventDetails, string>> eventQueue = 
            new Queue<KeyValuePair<JsonResponses.EventDetails, string>>();

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
            lyncClient = new LyncHttpClient() { Timeout = System.TimeSpan.FromHours(1.0d) };
            InitializeDictionary();
            nextLink = Program.ApplicationResource._links.events.href;
            samayeSamaye.Tick += samayeSamaye_Tick;
            samayeSamaye.Start();
            GetEvents();
        }

        static async void samayeSamaye_Tick(object sender, System.EventArgs e)
        {
            samayeSamaye.Stop();
            while (eventQueue.Count > 0)
            {
                await ProcessLastResponse(eventQueue.Dequeue());
            }
            samayeSamaye.Start();
        }
    
        private static void InitializeDictionary()
        {
            eventDictionary.Add(EventNames.MessagingInvitationReceived, PromptIncomingMessage);
        }

        internal static async void GetEvents()
        {
            while (true)
            {
                var httpresponse = await lyncClient.GetStringAsync(nextLink);
                var response = JsonConvert.DeserializeObject<JsonResponses.EventDetails>(httpresponse);
                eventQueue.Enqueue(new KeyValuePair<JsonResponses.EventDetails, string>(response, httpresponse));
                nextLink = response._links.next.href;
            }
        }

        private static async Task ProcessLastResponse(KeyValuePair<JsonResponses.EventDetails,string> response)
        {
            var objResponse = JObject.Parse(response.Value);
            if (null != 
                (string)objResponse.
                SelectToken("sender[0].events[0]._embedded.messagingInvitation._links.accept.href"))
                    { await eventDictionary[EventNames.MessagingInvitationReceived].Invoke(response.Key); }
            
            if (null != 
                (string)objResponse.
                SelectToken("sender[0].events[0]._embedded.message._links.plainMessage.href"))
                    {
                if (String.Equals("incoming", response.Key.sender[0].events[0]._embedded.message.direction, StringComparison.OrdinalIgnoreCase))
                        {
                            UI.MainForm.chatBox.Text =
                             string.Concat(
                                 UI.MainForm.chatBox.Text,
                                 Environment.NewLine,
                                 Environment.NewLine,
                                 Properties.Settings.Default.CurrentSender, ": ",
                                 getDatafromStream(response.Key.sender[0].events[0]._embedded.message._links.plainMessage.href.Replace("data:text/plain;charset=utf-8,", "")));
                        }
                    }

            if (null != 
                (string)objResponse.
                SelectToken("sender[0].events[2]._embedded.messaging._links.sendMessage.href"))
            { 
                if (Properties.Settings.Default.CurrentConvo.Trim().Length == 0)
                {
                            Properties.Settings.Default.CurrentConvo = (string)objResponse.
                                SelectToken("sender[0].events[2]._embedded.messaging._links.sendMessage.href");
                }
            }
            else if (null !=
                (string)objResponse.
                SelectToken("sender[1].events[3]._embedded.messaging._links.sendMessage.href"))
            {
                if (Properties.Settings.Default.CurrentConvo.Trim().Length == 0)
                {
                    Properties.Settings.Default.CurrentConvo = (string)objResponse.
                        SelectToken("sender[1].events[3]._embedded.messaging._links.sendMessage.href");
                }
            }
        }

        private static async Task PromptIncomingMessage(JsonResponses.EventDetails details)
        {
            await lyncClient.PostAsync(details.sender[0].events[0]._embedded.messagingInvitation._links.accept.href, new System.Net.Http.StringContent(""));
            Properties.Settings.Default.CurrentSender = details.sender[0].events[0]._embedded.messagingInvitation._embedded.from.name;
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
            var baha = System.Web.HttpUtility.UrlDecode(text, System.Text.Encoding.UTF8);
            return baha;
        }

    }   
}