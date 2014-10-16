using System.Collections.Generic;
using System.Text;

namespace LyncUCWA.Service
{
    public class RestServiceHelper
    {
        private readonly string _requestUrl;
        private readonly Headers _headers;

        public RestServiceHelper(string url, Headers headers)
        {
            _requestUrl = url;
            this._headers = headers;
        }

        public RestServiceHelper(Headers headers)
        {
            _requestUrl = ServiceCallManager.ServiceUrl;
            this._headers = headers;
        }
    }
}