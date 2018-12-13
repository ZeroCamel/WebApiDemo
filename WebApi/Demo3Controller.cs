using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApi
{
    /// <summary>
    /// TODO:验证HttpRoutingDispatcher的路由功能
    /// </summary>
    public class Demo3Controller:ApiController
    {
        public async Task<IDictionary<string,object>> Get()
        {
            HttpConfiguration configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute("default","wheather/{areacode}/{days}");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"http://www.artech.com/wheather/010/2");
            MyHttpRoutingDispatcher dispatcher = new MyHttpRoutingDispatcher(configuration);
            await dispatcher.SendAsync(request, CancellationToken.None);

            //路由数据会在HttpRoutingDispatcher的SendAsync方法执行的时候生成的
            IHttpRouteData routData = request.GetRouteData();
            return routData.Values;
        }
    }
}
