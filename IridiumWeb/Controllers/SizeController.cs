using IridiumWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IridiumWeb.Controllers
{
    public class SizeController : ApiController
    {
        ValueContext db;
        SizeController()
        {
            db = new ValueContext();
        }
        //GET api/values
        [HttpGet]
        public int Size()
        {
            int count = db.Values.Count();
            return count;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
