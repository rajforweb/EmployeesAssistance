using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using EmployeeAssistance.Api.Models;
using System.Linq;
using EmployeeAssistance.DataAccess;
using MongoDB.Bson;


namespace EmployeeAssist.WebApi.Controllers
{
    public class EditorController : ApiController
    {
        // GET: Editor
        [Route("api/Create")]
        [HttpPost]
        public void Create([FromBody]EditorModel model)
        {
            IMongoDAL dal = new MongoDAL();
            dal.Insert(model.Country, model.State, model.City, model.Category, model.SubCategory, 0, model.Information[0].Description);
        }

        // GET: Editor
        [Route("api/Update/like")]
        [HttpPost]
        public ListItem Update([FromBody]Information model)
        {
            IMongoDAL dal = new MongoDAL();
            return new ListItem { Id= "Like", Value= dal.Like(model.Id).ToString() };
        }

    }
}