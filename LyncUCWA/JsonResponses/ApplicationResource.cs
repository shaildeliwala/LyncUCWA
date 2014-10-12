namespace LyncUCWA.JsonResponses
{
    public class ApplicationResponse : ClsHref
    {
        public Link _links { get; set; }
        public Embedded _embedded { get; set; }
        public string userAgent { get; set; }
        public string endpointId { get; set; }
        public string culture { get; set; }
    }

}
