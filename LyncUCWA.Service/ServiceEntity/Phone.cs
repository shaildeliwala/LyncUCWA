namespace LyncUCWA.Service.ServiceEntity
{
    public class Phone : ClsHref
    {
        public string number { get; set; }
        public bool includeInContactCard { get; set; }
        public string type { get; set; }
        public Link _links { get; set; }
        public string etag { get; set; }
    }
}
