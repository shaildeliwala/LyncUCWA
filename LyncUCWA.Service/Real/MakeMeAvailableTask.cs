using LyncUCWA.Service.Interface;
using LyncUCWA.Service.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Real
{
    public class MakeMeAvailableTask : IMakeMeAvailableTask
    {
        public async Task<BaseResponse> MakeMeAvailable()
        {
            var payload = new {
                status = "Online",
                modalities = new List<string>() { "Messaging", "PhoneAudio" } };

            var content = new StringContent(
                content: JsonConvert.SerializeObject(payload, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }),
                encoding: Encoding.UTF8,
                mediaType: "application/json");

            return await ServiceCallManager.SendData<BaseResponse>(
                Configuration.Instance().CurrentApplication._embedded.me._links.makeMeAvailable.href,
                HttpMethod.Post,
                content);
        }
    }
}