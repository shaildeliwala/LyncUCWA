using LyncUCWA.Service.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace LyncUCWA.Service
{
    public class ServiceCallManager
    {
        private static HttpClient _httpClient;

        public static string ServiceUrl
        {
            get { return "https://my.domainname.com/"; }
        }

        public static async Task<TResponse> SendData<TResponse>(string url, HttpMethod method = null, HttpContent content = null) where TResponse : BaseModel
        {
            var request = new HttpRequestMessage(method, url);
            HttpResponseMessage response;
            method = method ?? HttpMethod.Get;
            if (content != null)
                request.Content = content;
            using (var httpClient = new HttpClient())
            {
                response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var returnObject = JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
                    returnObject.Response = response;
                    return returnObject;
                }
            }
            return new BaseModel() { Response = response } as TResponse;
        }
    }
}