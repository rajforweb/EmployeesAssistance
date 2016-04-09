using System.Collections.Generic;
using System.Web.Http;
using EmployeeAssistance.Api.Models;
using EmployeeAssistance.DataAccess;
using MongoDB.Bson;
using System.Linq;

namespace EmployeeAssist.WebApi.Controllers
{
    public class ReaderController : ApiController
    {
        // GET: Editor
        [Route("api/Read")]
        [HttpGet]
        public List<Information> GetAllRecords([FromBody]CategoryModel model)
        {
            IMongoDAL dal = new MongoDAL();
            var result = dal.GetInformation(model.Country, model.State, model.City, model.Category, model.SubCategory);

            var response = new List<Information>();
            if (result.Any())
            {
                
                foreach (var item in result)
                {
                    var responseItem = new Information();
                    responseItem.Likes = item["Likes"].ToString();
                    responseItem.Description = item["Description"].ToString();
                    responseItem.PostDate = item["PostDate"].ToString();
                    responseItem.Id = item["_id"].ToString();
                    response.Add(responseItem);
                }
            }
            
            
            return response;
        }

    }
}