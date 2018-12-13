using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost.Channels;

namespace WebApi
{
    /// <summary>
    /// 创建自定义的HttpServer模拟自我宿主的HTTPSERVER
    /// </summary>
    public class MyHttpSelfHostServer:HttpServer
    {
        public Uri BaseAddress { get; private set; }
        public IChannelListener<IReplyChannel> ChannelListener { get; private set; }
        public MyHttpSelfHostServer(HttpConfiguration configuration,Uri baseAddress):base(configuration)
        {
            this.BaseAddress = BaseAddress;
        }

        public void Open()
        {
            HttpBinding binding = new HttpBinding();
            this.ChannelListener=bindin
        }
    }
}
