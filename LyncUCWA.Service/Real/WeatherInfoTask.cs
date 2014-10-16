using LyncUCWA.Service.Interface;
using LyncUCWA.Service.Response;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Real
{
    public class WeatherInfoTask : IWeatherInfoTask
    {
        public async Task<WeatherResponse> GetWeatherByCity(string city)
        {
            return await ServiceCallManager.SendData<WeatherResponse>("http://api.openweathermap.org/data/2.5/weather?q=" + city);
        }
    }
}
