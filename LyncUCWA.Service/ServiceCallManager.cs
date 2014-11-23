using LyncUCWA.Service.Interface;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace LyncUCWA.Service
{
    public class ServiceCallManager
    {
        public static async Task<TResponse> SendData<TResponse>(string url, HttpMethod method = null, HttpContent content = null) where TResponse : class, IBaseModel, new()
        {
            method = method ?? HttpMethod.Get;
            var request = new HttpRequestMessage(method, url);
            HttpResponseMessage response;
            if (content != null)
                request.Content = content;
            using (var httpClient = new UCWAHttpClient())
            {
                response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var returnObject = JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
                    returnObject.Response = response;
                    return returnObject;
                }
            }
            return new TResponse() { Response = response };
        }
    }
}
