using LyncUCWA.Service.Interface;
using System;
using System.Collections.Generic;

namespace LyncUCWA.Service
{
    public class ServiceFactory<T> where T : IBaseTask
    {
        private static Dictionary<Type, Type> ObjectFactory = new Dictionary<Type, Type>()
        {
            //Phase 1:
            {typeof(IWeatherInfoTask), typeof(Real.WeatherInfoTask)},
            {typeof(IMakeMeAvailableTask), typeof(Real.MakeMeAvailableTask)}
        };
        public static T CreateObject()
        {
            var business = Activator.CreateInstance(ObjectFactory[typeof(T)]);
            return (T)business;
        }
    }
}