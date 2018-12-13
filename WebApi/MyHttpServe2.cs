using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{
    public class MyHttpServe2 : HttpServer
    {
        public new Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken calletionToken)
        {
            return base.SendAsync(request, calletionToken);
        }
    }
}
