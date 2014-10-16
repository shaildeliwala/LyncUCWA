using LyncUCWA.Service.Response;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Interface
{
    public interface IWeatherInfoTask : IBaseTask
    {
        Task<WeatherResponse> GetWeatherByCity(string city);


    }
}
