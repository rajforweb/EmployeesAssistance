using EmployeeAssistance.Models;
using EmployeeAssistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAssistance.Controllers
{
    public class EditorController : Controller
    {
        List<ListItem> defaultListItem = new List<ListItem>() { new ListItem() { Id = "", Value = "---select---" } };
        // GET: Search

        // GET: Editory
        public ActionResult Index()
        {
            ReaderRepository repo = new ReaderRepository();
            CategoryRepository catRepo = new CategoryRepository();
            ReaderViewModel model = new ReaderViewModel();
            model.CountryOptions = repo.GetCountry();
            model.StateOptions = defaultListItem;
            model.CityOptions= defaultListItem;
            model.CategoryOptions = catRepo.GetCategory();
            model.SubCategoryOptions = catRepo.GetSubCategory();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ReaderViewModel model)
        {

            model.CountryOptions = defaultListItem;
            model.StateOptions = defaultListItem;
            model.CityOptions = defaultListItem;
            model.CategoryOptions = defaultListItem;
            model.SubCategoryOptions = defaultListItem;

            EditorRepository repo = new EditorRepository();
            repo.AddAssistData(model);

            CategoryRepository catRepo = new CategoryRepository();
            ReaderRepository repoReader = new ReaderRepository();
            //CategoryRepository catRepo = new CategoryRepository();
            //ReaderViewModel models = new ReaderViewModel();
            model.CountryOptions = repoReader.GetCountry();
            model.CategoryOptions = catRepo.GetCategory();
            model.SubCategoryOptions = catRepo.GetSubCategory();
          
            model.save = true;
            model.information[0].Description = "";
            return View(model);
        }
    }
}