using System;
using System.Web;
using System.Web.Http;

namespace WebApi
{
    //将基类受保护的方法SendAsync转化为子类的公共方法以便可以直接调用
    public class MyHttpServer : HttpServer
    {
        public MyHttpServer(HttpConfiguration configuration):base(configuration)
        { }

        //New 关键词 暗渡陈仓 将父方法隐藏以便直接调用子类 与父方法解耦
        public new void Initialize()
        {
            base.Initialize();
        }
    }
}
