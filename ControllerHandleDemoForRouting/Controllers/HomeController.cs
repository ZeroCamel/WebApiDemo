using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.IO;
using System.Web.Routing;
using System.Web.Http.WebHost;
using System.Web.Http.Routing;

namespace ControllerHandleDemoForRouting.Controllers
{
    /// <summary>
    /// 验证HttpControllerHandler的路由功能
    /// </summary>
    public class HomeController : Controller
    {
        // GET: Home
        public void Index()
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute("weather","wheather/{areacode}/{days}");

            HttpRequest request = new HttpRequest("wheather.aspx", "http://www.artech.com/wheather/010/2", null);
            HttpResponse response = new HttpResponse(new StringWriter());
            HttpContext context = new HttpContext(request,response);

            //RouteData-获取包含请求的路由值
            RouteData routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(context));
            HttpControllerHandler httpHandler = new HttpControllerHandler(routeData,new HttpRouteDataTraceHandler());
            httpHandler.ProcessRequestAsync(context).Wait();
               
        }
    }
}