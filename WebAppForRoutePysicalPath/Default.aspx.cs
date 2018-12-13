using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppForRoutePysicalPath
{
    public partial class Default : System.Web.UI.Page
    {
        public enum RouteOrRouteCollection
        {
            Route,
            RouteCollection
        }
        public RouteData GetRouteData(RouteOrRouteCollection routeOrCollection,bool routeExistFile4Collection,bool routeExistFile4Route)
        {
            RouteValueDictionary defaults = new RouteValueDictionary()
            {
                {"areacode","010" },
                {"days","2" }
            };

            Route route = new Route("{areacode}/{days}",defaults,null);
            route.RouteExistingFiles = routeExistFile4Route;
            HttpContextBase context = CreateHttpContext();

            if (routeOrCollection==RouteOrRouteCollection.Route)
            {
                return route.GetRouteData(context);
            }

            RouteCollection routes = new RouteCollection();
            routes.Add(route);
            routes.RouteExistingFiles = routeExistFile4Collection;
            return routes.GetRouteData(context);
        }

        public static HttpContextBase CreateHttpContext()
        {
            HttpRequest request = new HttpRequest("~/weather.aspx","http://localhost:3543/weather.aspx",null);
            HttpResponse response = new HttpResponse(new StringWriter());

            //两者的相互转换 HttpContext《=》HttpContextBase
            HttpContext context = new HttpContext(request, response);
            HttpContextBase contextWrapper = new HttpContextWrapper(context);
            return contextWrapper;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}