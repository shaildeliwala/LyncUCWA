using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyncTest.JsonResponses
{
    class MyContacts : ClsHref
    {
        public Link _links { get; set; }
        public Embedded _embedded { get; set; }
    }

    public class Contact : ClsHref
    {
        public string uri { get; set; }
        public string sourceNetwork { get; set; }
        public List<string> emailAddresses { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public Link _links { get; set; }
        public string etag { get; set; }
    }

}
