using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyncTest
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
