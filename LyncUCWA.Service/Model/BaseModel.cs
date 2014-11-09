using LyncUCWA.Service.Interface;
using System.Net.Http;

namespace LyncUCWA.Service.Model
{
    public class BaseModel : IBaseModel
    {
        public HttpResponseMessage Response { get; set; }
    }
}
