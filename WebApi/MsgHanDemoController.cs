using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{
    /// <summary>
    /// TODO:自定义消息处理管道
    /// </summary>
    public class MsgHanDemoController : ApiController
    {
        /// <summary>
        /// 主方法
        /// </summary>
        /// <returns></returns>
        public Tuple<IEnumerable<string>,IEnumerable<string>> Get()
        {
            HttpConfiguration configuration = new HttpConfiguration();
            configuration.MessageHandlers.Add(new FooHandler());
            configuration.MessageHandlers.Add(new BarHandler());
            configuration.MessageHandlers.Add(new BazHandler());

            //构造HttpServer
            MyHttpServer httpserver = new MyHttpServer(configuration);
            IEnumerable<string> chain1 = this.GetHandlerChain(httpserver).ToArray();
            //消息管道的构建发生点
            httpserver.Initialize();
            IEnumerable<string> chain2 = this.GetHandlerChain(httpserver).ToArray();
            return new Tuple<IEnumerable<string>, IEnumerable<string>>(chain1, chain2);

        }

        /// <summary>
        /// TODO:辅助方法 获取消息处理管道原型链
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        private IEnumerable<string> GetHandlerChain(DelegatingHandler handler)
        {
            yield return handler.GetType().Name;
            while (handler.InnerHandler != null)
            {
                yield return handler.InnerHandler.GetType().Name;
                handler = handler.InnerHandler as DelegatingHandler;
                if (null == handler)
                {
                    break;
                }
            }
        }
    }
}
