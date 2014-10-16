using LyncUCWA.Service.Interface;
using LyncUCWA.Service.Response;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Mock
{
    public class MakeMeAvailableTask : IMakeMeAvailableTask
    {
        public async Task<BaseResponse> MakeMeAvailable()
        {
            return await Task<BaseResponse>.Run(() => new BaseResponse() { Response = new HttpResponseMessage(HttpStatusCode.OK) });
        }
    }
}