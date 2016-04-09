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
            return null;
        }

        List<BsonDocument> IMongoDAL.GetSubCategory(string Category)
        {
            return null;
        }
               

        void IMongoDAL.Insert(string country, string state, string city, string category, string subcategory, int Likes, string Description)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("assist");
            var collection = db.GetCollection<BsonDocument>("employeeassist");

            var record = new BsonDocument
            {
                { "Country" , country },
                { "State", state},
                { "City", city },
                { "Category", category },
                { "SubCategory" , subcategory },               
                { "Likes" , Likes },
                { "Description" , Description }

            };

            collection.InsertOne(record);
        }


        void IMongoDAL.InsertCategorySubCategory(string category, string subcategory)
        {
            
        }

    }

}
