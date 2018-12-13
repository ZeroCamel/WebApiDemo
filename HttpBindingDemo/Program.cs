using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;//ObjectContent JsonMediaTypeFormatter
using System.Reflection;
using System.ServiceModel.Channels; //Binding
using System.Web.Http.SelfHost.Channels; //HttpBinding


namespace HttpBindingDemo
{
    /// <summary>
    /// WCF信道处理 HttpBinding 监听服务器 指定监听地址127.0.0.1:3721
    /// </summary>
    class Program
    {
        /// <summary>
        /// 网络监听任务ChannelListener管道创建的消息处理管道最终实现了对请求的接收和响应的发送
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            
            //1、httpselfhost openAsync开启之后逻辑
            Uri listenUri = new Uri("http://127.0.0.1:3721");
            Binding binding = new HttpBinding();
            
            //创建 开启 信道监听器
            IChannelListener<IReplyChannel> channelListener = binding.BuildChannelListener<IReplyChannel>(listenUri);
            //可以使用异步的方式开启
            //channelListener.BeginOpen();
            channelListener.Open();
           

            //创建 开启 回复信道
            IReplyChannel channel = channelListener.AcceptChannel(TimeSpan.FromDays(24));
            channel.Open();

            while (true)
            {
                RequestContext requestContext = channel.ReceiveRequest(TimeSpan.MaxValue);
                PrintRequestMessage(requestContext.RequestMessage);
                //消息回复
                requestContext.Reply(CreateResponseMessage());
            }


        }

        /// <summary>
        /// HttpMessage对象 由于这是个内部类型 所以只能以反射的方式调用GetHttpRequestMessage
        /// </summary>
        /// <param name="message"></param>
        private static void PrintRequestMessage(Message message)
        {
            MethodInfo method = message.GetType().GetMethod("GetHttpRequestMessage");
            HttpRequestMessage request = (HttpRequestMessage)method.Invoke(message, new object[] { false });

            Console.WriteLine("{0,-15},{1}", "RequestUri", request.RequestUri);
            foreach (var header in request.Headers)
            {
                Console.WriteLine("{0,-15}:{1}", header.Key, string.Join(",", header.Value.ToArray()));
            }
        }

        private static Message CreateResponseMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            Employee employee = new Employee("001", "Ponyo", "123456", "aponyo@hotmail.com");

            //Base class to handle serializing and deserializing strongly-typed objects using ObjectContent.
            response.Content = new ObjectContent<Employee>(employee, new JsonMediaTypeFormatter());

            string httpMessageTypeName = "System.Web.Http.SelfHost.Channels.HttpMessage,System.Web.Http.SelfHost";
            Type httpMessageType = Type.GetType(httpMessageTypeName);

            return (Message)Activator.CreateInstance(httpMessageType, new object[] { response });
        }
    }
}
