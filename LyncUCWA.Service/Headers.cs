using LyncUCWA.Service.Request;
using LyncUCWA.Service.Model;
using System.Collections.Generic;

namespace LyncUCWA.Service
{
    public enum Header
    {
        LyncUCWASessionToken = 0,
    }

    public class Headers
    {
        internal Dictionary<string, string> RequestHeaders { get; private set; }
        private readonly BaseModel _response;
        private readonly BaseRequest _request;

        public Headers(BaseModel response, BaseRequest request = null)
        {
            RequestHeaders = new Dictionary<string, string>();
            _response = response;
            _request = request;
            BuildHeaders();
        }

        public void AddHeaders(Header header, string value)
        {
            RequestHeaders.Add(header.ToString(), value);
        }

        public void AddHeaders(string header, string value)
        {
            RequestHeaders.Add(header, value);
        }

        private void BuildHeaders()
        {
            this.AddHeaders("Accept", "application/json");
            this.AddHeaders("Content-Type", "application/json");
        }
    }
}