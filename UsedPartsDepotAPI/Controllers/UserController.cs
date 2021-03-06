﻿using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;
using UsedPartsDepotAPI.Models;

namespace UsedPartsDepotAPI.Controllers
{
    public class UserController : ApiController
    {
        public static string connectionString = "mongodb://localhost";
        public static MongoClient client = new MongoClient(connectionString);
        public static IMongoDatabase database = client.GetDatabase("partsDepot");
        public static IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("PartsDepot");


        // GET: api/parts
        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            var result = collection.Find(_ => true).Project("{lastModified: 0}").ToList().ToJson();

            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "text/html")
            };
        }

        // GET: api/parts
        // GET: api/parts
        [HttpPut]
        public HttpResponseMessage Login(string email, string password)
        {
            try
            {
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.And(builder.Eq("email", email), builder.Eq("password", password));
                var result = collection.Find(filter).First();

                return new HttpResponseMessage()
                {
                    Content = new StringContent(result.ToString(), Encoding.UTF8, "text/html")
                };
            }
            catch
            {
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            }
           
        }

        // GET: api/parts/5
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = collection.Find(filter).Project("{ lastModified: 0}").First().ToJson();

            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "text/html")
            };
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]User value)
        {
            string result = "";
            try
            {
                collection.InsertOne(new BsonDocument(value.ToBsonDocument()));
                result = "Inserted"; 
            }catch(Exception e)
            {
                result = e.ToString();
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "text/html")
            };

        }

        [HttpPut]
        public HttpResponseMessage Put(string id, string fName, string lName, string dateJoined, string Email, string Password)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.Set("userFirst", fName).Set("userLast", lName).Set("joinDate", dateJoined).Set("Email", Email).Set("Password", Password).CurrentDate("lastModified");
            var result = collection.UpdateMany(filter, update);

            return new HttpResponseMessage()
            {
                Content = new StringContent(result.ToString(), Encoding.UTF8, "text/html")
            };
        }

        // DELETE: api/parts/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)); ;
            var result = collection.DeleteOne(filter);

            return new HttpResponseMessage()
            {
                Content = new StringContent(result.ToString(), Encoding.UTF8, "text/html")
            };
        }
    }
}
