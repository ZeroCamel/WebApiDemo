using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CosoleAppInvokeHttpMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpclient1 = new HttpClient();
            HttpClient httpclient2 = new HttpClient();
            HttpClient httpclient3 = new HttpClient();
            HttpClient httpclient4 = new HttpClient();

            httpclient3.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "PUT");
            httpclient4.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "DELETE");

            Console.WriteLine("{0,-7}{1,-24}{2,-6}", "Method", "X-HTTP-Method-Override", "Action");

            InvokeWebApi(httpclient1, HttpMethod.Get);
            InvokeWebApi(httpclient2, HttpMethod.Post);
            InvokeWebApi(httpclient3, HttpMethod.Post);
            InvokeWebApi(httpclient4, HttpMethod.Post);


            //DateTime s = DateTime.Now;
            //DateTime e = Convert.ToDateTime("2018-10-28");
            //Console.WriteLine((e - s).Days);
            //List<string> s1 = new List<string>();
            //s1.Add("1");
            //s1.Add("2");
            //s1.Add("3");
            //Console.WriteLine(string.Join(",",s1));

            Console.Read();
        }

        async static void InvokeWebApi(HttpClient httpClient,HttpMethod method)
        {
            string requestUrl = "http://localhost:22447/api/httpmethod";
            HttpRequestMessage request = new HttpRequestMessage(method, requestUrl);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            IEnumerable<string> methodsOveride;

            httpClient.DefaultRequestHeaders.TryGetValues("X-HTTP-Method-Override",out methodsOveride);
            string actionName = response.Content.ReadAsStringAsync().Result;
            string methodOverride = methodsOveride == null ? "N/A" : methodsOveride.First();
            Console.WriteLine("{0,-7}{1,-24}{2,-6}",method,methodOverride,actionName.Trim('"'));
        }
    }
}
