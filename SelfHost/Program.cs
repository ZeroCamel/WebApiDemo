using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、程序集加载
            //宿主程序启动的时候不会主动加载程序集，由于当前应用程序集并不曾加载这些程序集，HttpController类型解析就会失败，
            //HttpController激活自然也就无法实现
            //Assembly.Load("WebApi,Version=1.0.0.0,Culture=neutral,PublicKeyToken=null");

            ////监听地址基地址
            //HttpSelfHostConfiguration configuration = new HttpSelfHostConfiguration("http://localhost/selfhost");
            ////自定义HttpSelfHostServer
            //using (HttpSelfHostServer httpServer = new HttpSelfHostServer(configuration))
            //{
            //    //获取全局路由表
            //    //寄宿方式获取配置方式
            //    httpServer.Configuration.Routes.MapHttpRoute(
            //        name: "DefaultApi",
            //        routeTemplate: "api/{controller}/{id}",
            //        defaults: new { id = RouteParameter.Optional }
            //        );
            //    //服务器开始监听来自网络的请求
            //    //会创建一个HttpBinding对象
            //    httpServer.OpenAsync();
            //    Console.Read();
            //}


            //2、验证自定义的HttpSelfHostServer
            using (MyHttpSelfHostServer httpServer = new MyHttpSelfHostServer(new HttpConfiguration(), new Uri("http://127.0.0.1:3721")))
            {
                httpServer.Configuration.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });
                httpServer.Open();
                Console.Read();
            };
        }
    }
}
