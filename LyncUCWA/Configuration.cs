using System;

namespace LyncUCWA
{
    public class Configuration
    {
        private static Configuration _instance;

        private Configuration()
        { }

        public static Configuration Instance()
        {
            return _instance ?? (_instance = new Configuration());
        }

        public Uri LyncServerUri
        {
            get
            {
                return new Uri("https://lyncdiscover.gotuc.net");
            }
        }
    }
}