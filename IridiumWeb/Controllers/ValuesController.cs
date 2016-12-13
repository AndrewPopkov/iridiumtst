using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IridiumWeb.Controllers
{
    public class ValuesController : ApiController
    {
        Stack<string> obj = new Stack<string>();

        // GET api/values
        [HttpGet]
        public string Peek()
        {
            return obj.Peek();
        }

        // GET api/values
        [HttpGet]
        public int Size()
        {
            return obj.Count;
        }

        // POST api/values/str
        [HttpPost]
        public void Push([FromBody]string value)
        {
            obj.Push(value);
        }

        // DELETE api/values
        [HttpDelete]
        public void Pop()
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}