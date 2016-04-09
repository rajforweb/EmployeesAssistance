using System.Collections.Generic;
using System.Web.Http;
using EmployeeAssistance.Api.Models;
using EmployeeAssistance.DataAccess;
using MongoDB.Bson;

namespace EmployeeAssist.WebApi.Controllers
{
    public class ReaderController : ApiController
    {
        // GET: Editor
        [Route("api/Read")]
        [HttpGet]
        public List<BsonDocument> GetAllRecords([FromBody]CategoryModel model)
        {
            IMongoDAL dal = new MongoDAL();
            var result = dal.GetInformation(model.Country, model.State, model.City, model.Category, model.SubCategory);
            return result;
        }

    }
}