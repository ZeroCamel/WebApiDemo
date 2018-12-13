using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{
    /// <summary>
    /// 定义HttpMethod
    /// </summary>
    public class HttpMethodController : ApiController
    {
        public string Get()
        {
            return "Get";
        }

        public string Post()
        {
            return "Post";
        }
        public string Put()
        {
            return "Put";
        }
        public string Delete()
        {
            return "Delete";
        }
    }
}
