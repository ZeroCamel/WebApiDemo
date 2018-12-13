using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{
    public class Demo2Controller:ApiController
    {
        //TODO:匿名Principal
        public IEnumerable<string> Get()
        {
            MyHttpServe2 httpServer = new MyHttpServe2();
            Thread.CurrentPrincipal = null;

            //1、第一次请求发送 Thread.CurrentPricipal==null
            HttpRequestMessage request = new HttpRequestMessage();
            httpServer.SendAsync(request,new CancellationToken(false));
            //1、输出标识
            GenericPrincipal principal = (GenericPrincipal)Thread.CurrentPrincipal;
            string identity1 = string.IsNullOrEmpty(principal.Identity.Name) ? "N/A" : principal.Identity.Name;

            //1、初始化识别标识Thread.CurrentPrincipal!=null
            GenericIdentity identity = new GenericIdentity("Artech");
            Thread.CurrentPrincipal = new GenericPrincipal(identity,new string[0]);
            //2、发送请求
            request = new HttpRequestMessage();
            httpServer.SendAsync(request, new CancellationToken(false));
            //3、获取标识并输出
            principal = (GenericPrincipal)Thread.CurrentPrincipal;
            string identity2 = string.IsNullOrEmpty(principal.Identity.Name) ? "N/A" : principal.Identity.Name;

            return new string[] { identity1, identity2 };
        }
    }
}
