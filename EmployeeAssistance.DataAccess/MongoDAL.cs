using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssistance.DataAccess
{
    public class MongoDAL : IMongoDAL
    {
        List<BsonDocument> IMongoDAL.GetInformation(string country, string state, string city, string category, string subcategory)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("assist");
            var collection = db.GetCollection<BsonDocument>("employeeassist");

            var builders = Builders<BsonDocument>.Filter;

            var filter = builders.Eq("Country", country);
            if (!string.IsNullOrEmpty(state)){
                filter = filter & builders.Eq("State", state);
            }
            if (!string.IsNullOrEmpty(city))
            {
                filter = filter & builders.Eq("City", city);
            }

            filter = filter & builders.Eq("Category", category)
             & builders.Eq("SubCategory", subcategory);

            List<BsonDocument> result = collection.Find(filter).ToList();
            return result;
        }

        List<BsonDocument> IMongoDAL.GetCategorySubCategory()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("assist");
            var collection = db.GetCollection<BsonDocument>("category");

            List<BsonDocument> result = collection.AsQueryable().ToList();
            return result;
        }

        List<BsonDocument> IMongoDAL.GetSubCategory(string Category)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("assist");
            var collection = db.GetCollection<BsonDocument>("category");

            var builders = Builders<BsonDocument>.Filter;

            var filter = builders.Eq("Category", Category);

            List<BsonDocument> result = collection.Find(filter).ToList();
            return result;

        }


        void IMongoDAL.Insert(string country, string state, string city, string category, string subcategory, int Likes, string Description)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("assist");
            var collection = db.GetCollection<BsonDocument>("employeeassist");
            DateTime time = DateTime.Now;
            string formatedTime = "";
            formatedTime = time.ToString("MM/dd/yyyy");   // 07/21/2007 
            var record = new BsonDocument
            {
                { "Country" , country },
                { "State", state??""},
                { "City", city??"" },
                { "Category", category },
                { "SubCategory" , subcategory },
                { "Likes" , Likes },
                { "Description" , Description },
                { "PostDate", formatedTime }

            };

            collection.InsertOne(record);
        }


        void IMongoDAL.InsertCategorySubCategory(string category, string subcategory)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("assist");
            var collection = db.GetCollection<BsonDocument>("category");

            var record = new BsonDocument
            {
                { "Category", category },
                { "SubCategory" , subcategory },
            };

            collection.InsertOne(record);
        }

        public int Like(string informationId)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("assist");
            var collection = db.GetCollection<BsonDocument>("employeeassist");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(informationId));

            Int32 likes = 0;
            var result = collection.Find(filter).ToList();
            if (result.Any())
            {


                likes = Convert.ToInt32(result[0]["Likes"]);
                likes += 1;

                var update = Builders<BsonDocument>.Update.Set("Likes", likes);

                collection.UpdateOne(filter, update);
                return likes;

            }

            return likes;
        }

    }

}
