using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PosServices
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("/ping")]
        public void Ping()
        {
        }

        [HttpGet]
        [Route("/test1")]
        public string Test1()
        {
            return "test 1 response";
        }

        [HttpPost]
        [Route("/test2")]
        public string Test2()
        {
            return "test 2 response";
        }
    }
}