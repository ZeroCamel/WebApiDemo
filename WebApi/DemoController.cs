using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApiRouteDemo.Controllers
{
    public class DemoController : ApiController
    {
        // GET: GetRouteData解决针对入栈请求的校验
        public IEnumerable<UrlResolutionResult> Get()
        {
            string routeTemplate = "movies/{genre}/{title}/{id}";
            IHttpRoute route = new HttpRoute(routeTemplate);
            var constraint = new HttpMethodConstraint(HttpMethod.Post);
            route.Constraints.Add("HttpMethod",constraint);

            string requestUri = "http://www.artech.com/api/movies/romance/titanic/001";
            //创建被检验的请求，具有相同的请求地址
            //采用Http方法不相同
            var request1 = new HttpRequestMessage(HttpMethod.Get,requestUri);
            var request2 = new HttpRequestMessage(HttpMethod.Post,requestUri);

            //不同虚拟根路径对HttpRoute的影响
            string root1 = "/";//不可达
            string root2 = "/api/";//可达

            IHttpRouteData routeData1 = route.GetRouteData(root1,request1);
            IHttpRouteData routeData2 = route.GetRouteData(root1, request1);
            IHttpRouteData routeData3 = route.GetRouteData(root2, request2);
            IHttpRouteData routeData4 = route.GetRouteData(root2, request2);

            
            yield return new UrlResolutionResult(root1,"Get",routeData1!=null);
            yield return new UrlResolutionResult(root1,"Post",routeData2!=null);
            yield return new UrlResolutionResult(root2,"Get",routeData3!=null);
            yield return new UrlResolutionResult(root2,"Post",routeData4!=null);
        }
    }

    public class UrlResolutionResult
    {
        public string VirtualPathRoot { get; set; }
        public string Method { get; set; }
        public bool Matched { get; set; }
        public UrlResolutionResult()
        { }

        public UrlResolutionResult(string virtualPathRoot,string method,bool matched)
        {
            this.VirtualPathRoot = virtualPathRoot;
            this.Method = method;
            this.Matched = matched;
        }
    }

}