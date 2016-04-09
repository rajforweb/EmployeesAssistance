using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssistance.DataAccess
{
    public interface IMongoDAL
    {
        List<BsonDocument> GetInformation(string country, string state, string city, string category, string subcategory);
        void Insert(string country, string state, string city, string category, string subcategory, int Likes, string Description, DateTime PostDate);
        void InsertCategorySubCategory(string category, string subcategory);
        List<BsonDocument> GetCategorySubCategory();
        List<BsonDocument> GetSubCategory(string category);
        int Like(string informationId);
    }
}
