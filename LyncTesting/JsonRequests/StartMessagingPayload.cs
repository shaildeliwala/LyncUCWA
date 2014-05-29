using Newtonsoft.Json;

namespace LyncTest.JsonRequests
{
    [JsonObject(MemberSerialization.OptOut)]
    public class StartMessagingPayload
    {
        /*
        JSON Schema:
            {
                "importance":"Normal",
                "sessionContext":"33dc0ef6-0570-4467-bb7e-49fcbea8e944",
                "subject":"Task Sample",
                "telemetryId":null,
                "to":"sip:lenea@contoso.com",
                "operationId":"5028e824-2268-4b14-9e59-1abad65ff393"
            }
        */
        [JsonProperty("importance")]
        public string importance { get; set; }

        [JsonProperty("sessionContext")]
        public string sessionContext { get; set; }

        [JsonProperty("subject")]
        public string subject { get; set; }

        [JsonProperty("telemetryId")]
        public string telemetryId { get; set; }

        [JsonProperty("to")]
        public string recipient { get; set; }

        [JsonProperty("operationId")]
        public string operationId { get; set; }

        internal StartMessagingPayload(string imp, string sesContext, string sub, string telemetryID, string to, string opId)
        {
            importance = imp;
            sessionContext = sesContext;
            subject = sub;
            telemetryId = telemetryID;
            recipient = to;
            operationId = opId;
        }
    }
}