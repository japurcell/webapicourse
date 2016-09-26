using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CarsController : ApiController
    {
        // GET: api/Cars
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cars/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cars
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cars/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cars/5
        public void Delete(int id)
        {
        }
    }
}
