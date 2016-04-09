using MongoDB.Bson;
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
            
        }


        void IMongoDAL.InsertCategorySubCategory(string category, string subcategory)
        {
            
        }

    }

}
}
