using LyncUCWA.Service.ServiceEntity;

namespace LyncUCWA.Service
{
    public class Configuration
    {
        private static Configuration _instance;
        private Configuration()
        {

        }

        public static Configuration Instance()
        {
            return _instance ?? (_instance = new Configuration());
        }

        public ApplicationResponse CurrentApplication { get; set; }
        internal MyContacts Contacts { get; set; }

    }
}
