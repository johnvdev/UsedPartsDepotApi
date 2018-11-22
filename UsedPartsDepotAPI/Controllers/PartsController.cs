using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UsedPartsDepotAPI.Controllers
{
    public class PartsController : ApiController
    {
        // GET: api/Parts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Parts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Parts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Parts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Parts/5
        public void Delete(int id)
        {
        }
    }
}
