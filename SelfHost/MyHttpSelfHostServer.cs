using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost.Channels;

namespace SelfHost
{
    /// <summary>
    /// 创建自定义的HttpServer模拟自我宿主的HTTPSERVER
    /// </summary>
    public class MyHttpSelfHostServer : HttpServer
    {
        public Uri BaseAddress { get; private set; }
        public IChannelListener<IReplyChannel> ChannelListener { get; private set; }
        //不再是HttpSelfHostConfiguration
        public MyHttpSelfHostServer(HttpConfiguration configuration, Uri baseAddress) : base(configuration)
        {
            BaseAddress = baseAddress;
        }

        //同步开启
        public void Open()
        {
            //开启监听
            HttpBinding binding = new HttpBinding();
            ChannelListener = binding.BuildChannelListener<IReplyChannel>(this.BaseAddress);
            ChannelListener.Open();

            //创建信道栈 最终返回栈顶的Channel
            IReplyChannel channel = this.ChannelListener.AcceptChannel();
            channel.Open();

            while (true)
            {
                RequestContext requestContext = channel.ReceiveRequest(TimeSpan.MaxValue);
                Message message = requestContext.RequestMessage;
                MethodInfo method = message.GetType().GetMethod("GetHttpRequestMessage");

                HttpRequestMessage request = (HttpRequestMessage)method.Invoke(message, new object[] { true });
                Task<HttpResponseMessage> processResponse = base.SendAsync(request, new CancellationTokenSource().Token);

                processResponse.ContinueWith(task =>
                {
                    string httpMessageTypeName = "System.Web.Http.SelfHost.Channels.HttpMessage,System.Web.Http.SelfHost";
                    Type httpMessageType = Type.GetType(httpMessageTypeName);
                    Message reply = (Message)Activator.CreateInstance(httpMessageType, new Object[] { task.Result });
                    requestContext.Reply(reply);

                });
            }
        }

        /// <summary>
        /// 同步关闭
        /// </summary>
        public void Close()
        {
            if (null!=ChannelListener&&this.ChannelListener.State==CommunicationState.Opened)
            {
                this.ChannelListener.Close();
            }
        }
    }
}
