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
           return null;
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
               

        void IMongoDAL.Insert(string country, string state, string city, string category, string subcategory, int Likes, string Description, DateTime PostDate)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("assist");
            var collection = db.GetCollection<BsonDocument>("employeeassist");
            var time = DateTime.Now;
            var record = new BsonDocument
            {
                { "Country" , country },
                { "State", state},
                { "City", city },
                { "Category", category },
                { "SubCategory" , subcategory },               
                { "Likes" , Likes },
                { "Description" , Description },
                { "PostDate", time }

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

    }

}
