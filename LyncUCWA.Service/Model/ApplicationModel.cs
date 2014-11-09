using LyncUCWA.Service.Interface;
using System.Net.Http;

namespace LyncUCWA.Service.Model
{
    public class ApplicationModel : ClsHref, IBaseModel
    {
        public Link _links { get; set; }
        public Embedded _embedded { get; set; }
        public string userAgent { get; set; }
        public string endpointId { get; set; }
        public string culture { get; set; }

        public HttpResponseMessage Response { get; set; }
    }
}
