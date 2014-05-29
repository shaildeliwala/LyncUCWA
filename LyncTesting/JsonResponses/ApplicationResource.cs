﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LyncTest.JsonResponses
{
    public class ApplicationResponse : ClsHref
    {
        public Link _links { get; set; }
        public Embedded _embedded { get; set; }
        public string userAgent { get; set; }
        public string endpointId { get; set; }
        public string culture { get; set; }
    }

    public class Link
    {
        public ClsHref self { get; set; }
        public ClsHref next { get; set; }
        public ClsHref user { get; set; }
        public ClsHref xframe { get; set; }
        public ClsHref policies { get; set; }
        public ClsHref batch { get; set; }
        public ClsHref events { get; set; }
        public ClsHref makeMeAvailable { get; set; }
        public ClsHref callForwardingSettings { get; set; }
        public ClsHref phones { get; set; }
        public ClsHref photo { get; set; }
        public ClsHref presenceSubscriptions { get; set; }
        public ClsHref subscribedContacts { get; set; }
        public ClsHref presenceSubscriptionMemberships { get; set; }
        public ClsHref myGroups { get; set; }
        public ClsHref myGroupMemberships { get; set; }
        public ClsHref myContacts { get; set; }
        public ClsHref myPrivacyRelationships { get; set; }
        public ClsHref myContactsAndGroupsSubscription { get; set; }
        public ClsHref search { get; set; }
        public ClsHref myOnlineMeetings { get; set; }
        public ClsHref onlineMeetingDefaultValues { get; set; }
        public ClsHref onlineMeetingEligibleValues { get; set; }
        public ClsHref onlineMeetingInvitationCustomization { get; set; }
        public ClsHref onlineMeetingPolicies { get; set; }
        public ClsHref phoneDialInInformation { get; set; }
        public ClsHref myAssignedOnlineMeeting { get; set; }
        public ClsHref conversations { get; set; }
        public ClsHref startMessaging { get; set; }
        public ClsHref startOnlineMeeting { get; set; }
        public ClsHref joinOnlineMeeting { get; set; }
        public ClsHref message { get; set; }
        public ClsHref from { get; set; }
        public ClsHref accept { get; set; }
        public ClsHref acceptedByContact { get; set; }
        public ClsHref cancel { get; set; }
        public ClsHref conversation { get; set; }
        public ClsHref stopMessaging { get; set; }
        public ClsHref sendMessage { get; set; }
        public ClsHref setlsTyping { get; set; }
        public ClsHref typingParticipants { get; set; }
        public ClsHref decline { get; set; }
        public ClsHref derivedMessaging { get; set; }
        public ClsHref messaging { get; set; }
        public ClsHref plainMessage { get; set; }
        public ClsHref onBehalfOf { get; set; }
        public ClsHref to { get; set; }
        public ClsHref addParticipant { get; set; }
        public ClsHref applicationSharing { get; set; }
        public ClsHref attendees { get; set; }
        public ClsHref audioVideo { get; set; }
        public ClsHref dataCollaboration { get; set; }
        public ClsHref disableAudienceMessaging { get; set; }
        public ClsHref disableAudienceMuteLock { get; set; }
        public ClsHref enableAudienceMessaging { get; set; }
        public ClsHref enableAudienceMuteLock { get; set; }
        public ClsHref leaders { get; set; }
        public ClsHref lobby { get; set; }
        public ClsHref localParticipant { get; set; }
        public Participant participant { get; set; }
        public ClsHref onlineMeeting { get; set; }
        public ClsHref phoneAudio { get; set; }
        public ClsHref contact { get; set; }
        public ClsHref contactPhoto { get; set; }
        public ClsHref contactPresence { get; set; }
        public ClsHref contactLocation { get; set; }
        public ClsHref contactNote { get; set; }
        public ClsHref contactSupportedModalities { get; set; }
        public ClsHref contactPrivacyRelationship { get; set; }
        public ClsHref eject { get; set; }
        public ClsHref admit { get; set; }
        public ClsHref demote { get; set; }
        public Me me { get; set; }
        public ClsHref promote { get; set; }
        public ClsHref reject { get; set; }

    }

    public class Me : ClsHref
    {
        public string name { get; set; }
        public string uri { get; set; }
        public Link _links { get; set; }
    }

    public class People : ClsHref
    {
        public Link _links { get; set; }
    }

    public class OnlineMeetings : ClsHref
    {
        public Link _links { get; set; }
    }

    public class Communication : ClsHref
    {
        public Link _links { get; set; }
        public List<string> supportedModalities { get; set; }
        public List<string> supportedMessageFormats { get; set; }
        public string etag { get; set; }
    }

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
        public Messaging messaging { get; set; }
        public Message message { get; set; }
    }

    public class ClsHref
    {
        [JsonProperty("href")]
        public string href { get; set; }

        public string rel { get; set; }
    }
}
