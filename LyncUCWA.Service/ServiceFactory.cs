using LyncUCWA.Service.Interface;
using System;

namespace LyncUCWA.Service
{
    public class ServiceFactory<T> where T : IBaseTask
    {
        public static T CreateObject()
        {
            string className = Common.ReadConfigValue(typeof(T).Name);
            var business = Activator.CreateInstance(Type.GetType(className));
            return (T)business;
        }
    }
}