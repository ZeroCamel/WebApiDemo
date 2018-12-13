using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiForHttpMethodOverride
{
    public class HttpOverrideMethodHandler:DelegatingHandler
    {
        /// <summary>
        /// 重写的SendAsync实现了对x-http-method-override的提取和对Http方法的重写，
        /// 最后调用基类的同名方法将处理后的请求传递给后续的HttpMessageHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToke"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToke)
        {
            IEnumerable<string> methodOverrideHandler;
            if (request.Headers.TryGetValues("X-HTTP-Method-Override",out methodOverrideHandler))
            {
                request.Method = new HttpMethod(methodOverrideHandler.First());
            }
            return base.SendAsync(request,cancellationToke);
        }                                                        
    }
}
