using LyncUCWA.Service.Model;
using System;

namespace LyncUCWA.Service
{
    public class Configuration
    {
        private static Configuration _instance;
        private readonly Uri _lyncServerUri = new Uri("https://lyncdiscover.gotuc.net");

        private Configuration()
        {

        }

        public static Configuration Instance()
        {
            return _instance ?? (_instance = new Configuration());
        }

        public ApplicationModel CurrentApplication { get; set; }
        internal MyContacts Contacts { get; set; }
        public Uri LyncServerUri { get { return _lyncServerUri; } }
        public Uri DomainAddress { get; set; }
        public string OAuthToken { get; set; }
    }
}
