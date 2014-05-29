using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyncTest.JsonResponses
{
    [JsonObject]
    public class EventDetails
    {
        [JsonProperty("_links")]
        public Link _links { get; set; }

        [JsonProperty("sender")]
        public List<Sender> sender { get; set; }
    }

    public class Message : ClsHref
    {
        public string direction { get; set; }
        public DateTime timeStamp { get; set; }
        public Link _links { get; set; }
    }

    public class Messaging : ClsHref
    {
        public string state { get; set; }
        public List<string> negotiatedMessageFormats { get; set; }
        public Link _links { get; set; }
    }

    public class Participant : ClsHref
    {
        public string title { get; set; }
    }

    public class AcceptedByParticipant
    {
        public string rel { get; set; }
        public bool anonymous { get; set; }
        public string name { get; set; }
        public bool organizer { get; set; }
        public string otherPhoneNumber { get; set; }
        public string role { get; set; }
        public string sourceNetwork { get; set; }
        public string uri { get; set; }
        public string workPhoneNumber { get; set; }
        public Link _links { get; set; }
    }

    public class From : ClsHref
    {
        public bool anonymous { get; set; }
        public string name { get; set; }
        public bool organizer { get; set; }
        public string otherPhoneNumber { get; set; }
        public string role { get; set; }
        public string sourceNetwork { get; set; }
        public string uri { get; set; }
        public string workPhoneNumber { get; set; }
        public Link _links { get; set; }
    }

    public class EmbeddedInMsgInv
    {
        public List<AcceptedByParticipant> acceptedByParticipant { get; set; }
        public From from { get; set; }
    }

    public class MessagingInvitation : ClsHref
    {
        public string direction { get; set; }
        public string importance { get; set; }
        public string operationId { get; set; }
        public string state { get; set; }
        public string subject { get; set; }
        public string threadId { get; set; }
        public string to { get; set; }
        public Link _links { get; set; }
        public EmbeddedInMsgInv _embedded { get; set; }
    }

    public class Conversation : ClsHref
    {
        public List<string> activeModalities { get; set; }
        public string audienceMessaging { get; set; }
        public string audienceMute { get; set; }
        public DateTime created { get; set; }
        public DateTime expirationTime { get; set; }
        public string importance { get; set; }
        public int participantCount { get; set; }
        public bool readLocally { get; set; }
        public bool recording { get; set; }
        public string state { get; set; }
        public string subject { get; set; }
        public string threadId { get; set; }
        public JsonResponses.Link _links { get; set; }
    }

    public class LocalParticipant : ClsHref
    {
        public bool anonymous { get; set; }
        public string name { get; set; }
        public bool organizer { get; set; }
        public string otherPhoneNumber { get; set; }
        public string role { get; set; }
        public string sourceNetwork { get; set; }
        public string uri { get; set; }
        public string workPhoneNumber { get; set; }
        public Link _links { get; set; }
    }

    public class Event
    {
        public ClsHref link { get; set; }
        public Embedded _embedded { get; set; }
        public string type { get; set; }
    }

    public class Sender : ClsHref
    {
        public List<Event> events { get; set; }
    }
}
