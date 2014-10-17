using LyncUCWA.Service.Interface;
using LyncUCWA.Service.Model;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Real
{
    public class WeatherInfoTask : IWeatherInfoTask
    {
        public async Task<WeatherModel> GetWeatherByCity(string city)
        {
            return await ServiceCallManager.SendData<WeatherModel>("http://api.openweathermap.org/data/2.5/weather?q=" + city);
        }
    }
}
