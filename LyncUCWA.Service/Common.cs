using System.Collections.Generic;

namespace LyncUCWA.Service
{
    public static class Common
    {
        private static Dictionary<string, string> ObjectFactory = new Dictionary<string, string>()
        {
            //Phase 1:
            {"IWeatherInfoTask", "LyncUCWA.Service.Real.WeatherInfoTask"},
            {"IMakeMeAvailableTask", "LyncUCWA.Service.Real.MakeMeAvailableTask"}
        };

        public static string ReadConfigValue(string key)
        {
            return ObjectFactory.ContainsKey(key) ? ObjectFactory[key] : string.Empty;
        }
    }
}