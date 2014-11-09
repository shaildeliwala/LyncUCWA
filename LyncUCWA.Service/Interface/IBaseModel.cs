using System.Net.Http;

namespace LyncUCWA.Service.Interface
{
    public interface IBaseModel
    {
        HttpResponseMessage Response { get; set; }
    }
}
