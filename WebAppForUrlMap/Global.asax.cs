using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebAppForUrlMap
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //1、指定路由模板变量
            //RouteValueDictionary defaults = new RouteValueDictionary();
            //defaults.Add("name", "*");
            //defaults.Add("id", "*");
            ////基于指定的路由模板创建一个Route对象，并将其添加到指定的路由表对象
            //RouteTable.Routes.MapPageRoute("Default", "employees/{name}/{id}", "~/Default.aspx", false, defaults);

            //2、天气-路由默认值
            //对请求的物理URL执行路由 http://localhost:36650/wether.aspx  areacode=wether.aspx
            RouteTable.Routes.RouteExistingFiles = true; //RouteCollection

            //注册忽略路由-需要放在注册路由之前，否则起不到任何作用
            RouteTable.Routes.Ignore("css/{filename}.css/{*pathInfo}");
            
            //设置默认路由
            RouteValueDictionary defaultss = new RouteValueDictionary {
                { "areacode","010"},
                { "days",2}
            };

            //基于正则表达式的约束
            //HttpMethodConstraint 针对Rest的资源架构
            RouteValueDictionary contains = new RouteValueDictionary {
                { "areacode",@"0\d{2,3}"},
                { "days",@"[1-3]"}
                //,{"httpMethod",new HttpMethodConstraint("POST") }
            };

            RouteValueDictionary dataTokens = new RouteValueDictionary {
                { "defaultCity","Beijing"},
                { "defaultDays",2}
            };

            //路由的名称-路由的URL模式-路由的物理URL-一个值指示是否应验证用户有权访问物理URL(始终会检查路由URL)-路由参数的默认值-路由约束-不用于确定路由是否匹配URL模式
            //路由注册方式1
            RouteTable.Routes.MapPageRoute("weather", "{areacode}/{days}", "~/Wether.aspx", false, defaultss, null, dataTokens);
            //路由注册方式2 IRouteHandle
            //Route route = new Route("{areacode}/{days}", defaultss, contains, dataTokens, new PageRouteHandler("~/Wether.aspx", false));
            //RouteTable.Routes.Add(route);

            //3、直接请求现存的物理文件
            //使用传统的方式访问存放于根目录下的Weather.aspx页面 
            //会发现并没有对请求地址实施路由 如果发生了路由 基于页面的RouteData不可能为空
            //！不对现有文件实施路由仅仅是默认采用的行为
            //RouteTable.Routes.RouteExistingFiles = true;

        }
    }
}