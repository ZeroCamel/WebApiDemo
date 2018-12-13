using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApiRouteDemo.Controllers
{
    public class DemoOneController : ApiController
    {
        // GET: GetVirtualData 根据路由规则路由变量生成一个完整的URL
        //变量的优先性 即使全部获得变量还需要满足一个隐晦的条件Httproot条件
        public IEnumerable<string> Get()
        {
            string routeTemplate = "weather/{areacode}/{days}";
            IHttpRoute route = new HttpRoute(routeTemplate);
            route.Defaults.Add("days", 2);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/");
            IHttpVirtualPathData pathData;

            //1、不能提供路由变量areacode的值
            Dictionary<string, object> values = new Dictionary<string, object>();
            pathData = route.GetVirtualPath(request, values);
            yield return pathData == null ? "N/A" : pathData.VirtualPath;

            //2、values无key为Httproute的元素  字典变量为路由变量提供了值
            values.Add("areacode", "028");
            pathData = route.GetVirtualPath(request,values);
            yield return pathData == null ? "N/A" : pathData.VirtualPath;

            //3、所有的路由变量值通过values提供 隐藏默认值 
            values.Add("httproute", true);
            values.Add("days",3);
            IHttpRouteData routeData = new HttpRouteData(route);
            //添加路由变量
            routeData.Values.Add("areacode", "0512");
            routeData.Values.Add("days", 4);
            //为HttpRequstMessage设置路由变量
            request.SetRouteData(routeData);
            pathData = route.GetVirtualPath(request, values);
            //注意days优先输出3 
            yield return pathData == null ? "N/A" : pathData.VirtualPath;

            //4、所有的路由变量值通过Request提供
            values.Clear();
            values.Add("httproute", true);
            pathData = route.GetVirtualPath(request,values);
            yield return pathData == null ? "N/A" : pathData.VirtualPath;

            //5、采用定义在HttpRoute上的默认值(da)
            routeData.Values.Remove("days");
            pathData = route.GetVirtualPath(request, values);
            yield return pathData == null ? "N/A" : pathData.VirtualPath;


        }
    }

}