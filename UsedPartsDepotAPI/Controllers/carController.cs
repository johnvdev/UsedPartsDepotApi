using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using UsedPartsDepotAPI.Models;

namespace UsedPartsDepotAPI.Controllers
{
    public class carController : ApiController
    {
        public static string connectionString = "mongodb://localhost";
        public static MongoClient client = new MongoClient(connectionString);
        public static IMongoDatabase database = client.GetDatabase("partsDepot");
        public static IMongoCollection<BsonDocument> collection =  database.GetCollection<BsonDocument>("PartsDepot");

        // GET: api/car/5
        public HttpResponseMessage Get(string userID)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(userID));
            var projection = Builders<BsonDocument>.Projection.Include("cars").Exclude("_id");
            var cars = collection.Find(filter).Project(projection).SingleOrDefault().ToJson();           

            return new HttpResponseMessage()
            {
                Content = new StringContent(cars, Encoding.UTF8, "text/html")
            };
        }

        // POST: api/car
        public HttpResponseMessage Post([FromBody]Car value, string userID)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(userID));
            var update = Builders<BsonDocument>.Update.Push("cars", new BsonDocument(value.ToBsonDocument()));
            var result = collection.UpdateOne(filter, update);

            if(result.IsAcknowledged)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }


           
        }

        // PUT: api/car/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/car/5
        public void Delete(int id)
        {
        }
    }
}
