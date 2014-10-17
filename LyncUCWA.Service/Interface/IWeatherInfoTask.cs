using LyncUCWA.Service.Model;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Interface
{
    public interface IWeatherInfoTask : IBaseTask
    {
        Task<WeatherModel> GetWeatherByCity(string city);


    }
}
