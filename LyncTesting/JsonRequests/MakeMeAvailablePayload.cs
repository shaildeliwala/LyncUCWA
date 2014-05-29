using Newtonsoft.Json;
using System.Collections.Generic;

namespace LyncTest.JsonRequests
{
    [JsonObject(MemberSerialization.OptOut)]
    public class MakeMeAvailablePayload
    {
        public string phoneNumber { get; set; }
        public string signInAs { get; set; }
        public List<string> supportedMessageFormats { get; set; }
        public List<string> supportedModalities { get; set; }

        internal MakeMeAvailablePayload(string number = "", string status = "", List<string> supportedMsgFormats = null, List<string> modalities = null)
        {
            phoneNumber = number;
            signInAs = status;
            supportedMessageFormats = supportedMsgFormats;
            supportedModalities = modalities;
        }
    }
}
