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
    public class PartsController : ApiController
    {
        public static string connectionString = "mongodb://localhost";
        public static MongoClient client = new MongoClient(connectionString);
        public static IMongoDatabase database = client.GetDatabase("partsDepot");
        public static IMongoCollection<BsonDocument> partsCollection = database.GetCollection<BsonDocument>("Parts");
        // PUT = insert or update; POST = insert
        // GET: api/Parts

        // GET: api/Parts/5
        [HttpGet]
        public HttpResponseMessage GetByVehicle([FromUri]string[] Vehicle)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Vehicle", Vehicle);
                var result = partsCollection.Find(filter).Project("{ lastModified: 0}").First().ToJson();

                return new HttpResponseMessage()
                {
                    Content = new StringContent(result, Encoding.UTF8, "text/html")
                };
            }
            catch(Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            }
     
        }

        //[HttpGet]
        //public HttpResponseMessage GetByUser(string UserID)
        //{
        //    var filter = Builders<BsonDocument>.Filter.Eq("UserID", UserID);
        //    var result = partsCollection.Find(filter).Project("{_id: 0, lastModified: 0}").First().ToJson();

        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(result, Encoding.UTF8, "text/html")
        //    };
        //}

        // POST: api/Parts
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Part value)
        {
            string result = "";
            try
            {
                partsCollection.InsertOne(new BsonDocument(value.ToBsonDocument()));
                result = "Inserted";
            }
            catch (Exception e)
            {
                result = e.ToString();
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "text/html")
            };
        }

        // PUT: api/Parts/5
        [HttpPut]
        public HttpResponseMessage Put(string id, Part part)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)); ;
            var update = Builders<BsonDocument>.Update.Set("UserID", part.UserID).Set("Title", part.Title).Set("Desc", part.Desc).Set("Price", part.Price).Set("Location", part.Location).Set("Vehicle", part.Vehicle).Set("Category", part.Category).CurrentDate("lastModified");
            var result = partsCollection.UpdateMany(filter, update);

            return new HttpResponseMessage()
            {
                Content = new StringContent(result.ToString(), Encoding.UTF8, "text/html")
            };
        }

        // DELETE: api/Parts/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)); ;
            var result = partsCollection.DeleteOne(filter);

            return new HttpResponseMessage()
            {
                Content = new StringContent(result.ToString(), Encoding.UTF8, "text/html")
            };
        }
    }
}
