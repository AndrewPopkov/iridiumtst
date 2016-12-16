using IridiumWeb.Models;
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
        ValueContext db;
        ValuesController()
        {
             db = new ValueContext();
        }

        // GET api/values
        [HttpGet]
        public Value Peek()
        {
            Value value = db.Values.OrderByDescending(val => val.Id).FirstOrDefault();
            return value;
        }

        // POST api/values/
        [HttpPost]
        public void Push([FromBody]Value value)
        {
            db.Values.Add(value);
            db.SaveChanges();
        }

        // DELETE api/values
        [HttpDelete]
        public Value Pop()
        {
            Value value = db.Values.OrderByDescending(val => val.Id).FirstOrDefault();
            if (value != null)
            {
                db.Values.Remove(value);
                db.SaveChanges();
            }
            return value;
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