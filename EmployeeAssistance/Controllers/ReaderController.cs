using EmployeeAssistance.Models;
using EmployeeAssistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAssistance.Controllers
{
    public class ReaderController : Controller
    {
        List<ListItem> defaultListItem = new List<ListItem>() { new ListItem() { Id = "", Value = "---select---" } };
        // GET: Reader
        public ActionResult Index()
        {
            ReaderRepository repo = new ReaderRepository();
            CategoryRepository catRepo = new CategoryRepository();
            ReaderViewModel model = new ReaderViewModel();
            model.CountryOptions = repo.GetCountry();
            model.StateOptions = defaultListItem;
            model.CityOptions = defaultListItem;
            model.CategoryOptions = catRepo.GetCategory();
            model.SubCategoryOptions = catRepo.GetSubCategory();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ReaderViewModel model)
        {
            var repoReader = new ReaderRepository();
            CategoryRepository catRepo = new CategoryRepository();

            model.CountryOptions = repoReader.GetCountry();
            model.StateOptions = (!string.IsNullOrWhiteSpace(model.Country)) ? repoReader.GetStates(model.Country) : defaultListItem;
            model.CityOptions = (!string.IsNullOrWhiteSpace(model.State)) ? repoReader.GetCity(model.State) : defaultListItem;
            model.CategoryOptions = catRepo.GetCategory();
            model.SubCategoryOptions = defaultListItem;
            model.information = repoReader.GetRecords(model);

            return View(model);
        }

        [HttpGet]
        public JsonResult GetStates(string country)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            ReaderRepository repo = new ReaderRepository();
            result.Data = repo.GetStates(country);
            return result;
        }

        [HttpGet]
        public JsonResult GetCities(string state)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            ReaderRepository repo = new ReaderRepository();
            result.Data = repo.GetCity(state);
            return result;
        }

        [HttpGet]
        public JsonResult UpdateLike(string informationId)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            ReaderRepository repo = new ReaderRepository();
            var listitem = repo.UpdateLike(informationId);
            result.Data = listitem;
            return result;
        }

    
    }
}