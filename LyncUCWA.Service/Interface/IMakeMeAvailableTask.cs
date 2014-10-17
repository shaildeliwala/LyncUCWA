using LyncUCWA.Service.Model;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Interface
{
    public interface IMakeMeAvailableTask : IBaseTask
    {
        Task<BaseModel> MakeMeAvailable();
    }
}