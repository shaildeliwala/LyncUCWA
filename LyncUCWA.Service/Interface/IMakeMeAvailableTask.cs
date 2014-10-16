using LyncUCWA.Service.Response;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Interface
{
    public interface IMakeMeAvailableTask : IBaseTask
    {
        Task<BaseResponse> MakeMeAvailable();
    }
}