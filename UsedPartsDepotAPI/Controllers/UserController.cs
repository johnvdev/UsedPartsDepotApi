using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsedPartsDepotAPI.Models;

namespace UsedPartsDepotAPI.Controllers
{
    public class UserController : ApiController
    {
        // GET api/values
        public string GetExtensiveUsers()
        {

        
            return  "";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            depotUser du = new depotUser();
            du.fName = "jeff";
            du.lName = "rickkyyyy";
            RetrievePartsDepotDB db = new RetrievePartsDepotDB();
            db.depotUsers.Add(du);
            db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
