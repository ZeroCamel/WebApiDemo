using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppForUrlMap
{
    public partial class Wether : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1、根据路由规则生成URL

            //指定路由数据 
            
            RouteData routeData = new RouteData();
            routeData.Values.Add("areacode","0512");
            routeData.Values.Add("days", "1");

            RequestContext requestContext = new RequestContext();
            requestContext.HttpContext = new HttpContextWrapper(HttpContext.Current);
            requestContext.RouteData = routeData;

            //指定路由模板变量
            RouteValueDictionary values = new RouteValueDictionary();
            values.Add("areacode","023");
            values.Add("days","3");

            Response.Write(RouteTable.Routes.GetVirtualPath(null,null).VirtualPath+"<br/>");
            Response.Write(RouteTable.Routes.GetVirtualPath(requestContext, null).VirtualPath + "<br/>");
            Response.Write(RouteTable.Routes.GetVirtualPath(requestContext, values).VirtualPath + "<br/>");
        }
    }
}