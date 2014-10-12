using Newtonsoft.Json;

namespace LyncUCWA.JsonRequests
{
     [JsonObject()]
    public class StartPhoneAudioPayload
    {
        [JsonProperty("operationId")]
        public string OperationId { get; set; }

        [JsonProperty("phoneNumber")]        
        public string PhoneNumber { get; set; }

        [JsonProperty("importance")]
        public string Importance { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("threadId")]
        public string ThreadId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }
}
