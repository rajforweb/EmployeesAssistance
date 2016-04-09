using EmployeeAssistance.Models;
using EmployeeAssistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAssistance.Controllers
{
    public class EditoryController : Controller
    {
        // GET: Editory
        public ActionResult Index()
        {
            ReaderRepository repo = new ReaderRepository();
            CategoryRepository catRepo = new CategoryRepository();
            ReaderViewModel model = new ReaderViewModel();
            model.CountryOptions = repo.GetCountry();
            model.StateOptions = repo.GetStates();
            model.CityOptions= repo.GetCity();
            model.CategoryOptions = catRepo.GetCategory();
            //model.SubCategoryOptions = catRepo.GetSubCategory();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ReaderViewModel model)
        {
            ReaderRepository repo = new ReaderRepository();
            CategoryRepository catRepo = new CategoryRepository();
            ReaderViewModel model = new ReaderViewModel();
            model.CountryOptions = repo.GetCountry();
            model.StateOptions = repo.GetStates();
            model.CityOptions = repo.GetCity();
            model.CategoryOptions = catRepo.GetCategory();
            //model.SubCategoryOptions = catRepo.GetSubCategory();

            return View(model);
        }
    }
}