using Newtonsoft.Json;

namespace LyncTest.JsonRequests
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Applications
    {
        /*
        JSON Schema:
            {
                "UserAgent":"UCWA Samples",
                "EndpointId":"a917c6f4-976c-4cf3-847d-cdfffa28ccdf",
                "Culture":"en-US",
            }
        */

        [JsonProperty("UserAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("EndpointId")]
        public string EndpointId { get; set; }

        [JsonProperty("Culture")]
        public string Culture { get; set; }

        internal Applications(string userAgent, string endpointId, string culture = "en-us")
        {
            UserAgent = userAgent;
            EndpointId = endpointId;
            Culture = culture;
        }
    }
}
