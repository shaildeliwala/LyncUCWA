using System.Collections.Generic;

namespace LyncUCWA.Service.Model
{
    public class Embedded
    {
        public Me me { get; set; }
        public People people { get; set; }
        public OnlineMeetings onlineMeetings { get; set; }
        public Communication communication { get; set; }
        public MessagingInvitation messagingInvitation { get; set; }
        public Conversation conversation { get; set; }
        public LocalParticipant localParticipant { get; set; }
        public List<Contact> contact { get; set; }
        public List<Phone> phone { get; set; }
        public Messaging messaging { get; set; }
        public Message message { get; set; }
    }
}
