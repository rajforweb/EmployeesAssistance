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
        // GET: Reader
        public ActionResult Index()
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