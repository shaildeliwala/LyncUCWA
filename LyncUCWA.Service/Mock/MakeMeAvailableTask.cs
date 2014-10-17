using LyncUCWA.Service.Interface;
using LyncUCWA.Service.Model;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Mock
{
    public class MakeMeAvailableTask : IMakeMeAvailableTask
    {
        public async Task<BaseModel> MakeMeAvailable()
        {
            return await Task<BaseModel>.Run(() => new BaseModel() { Response = new HttpResponseMessage(HttpStatusCode.OK) });
        }
    }
}