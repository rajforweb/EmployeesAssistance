using EmployeeAssistance.Models;
using EmployeeAssistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAssistance.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [HttpPost]
        public ActionResult AddCategory(CategoryModel model)
        {
            if (!string.IsNullOrEmpty(model.Category) && !string.IsNullOrEmpty(model.SubCategory))
                new CategoryRepository().AddCategory(model);
            return RedirectToAction("Index", "Editor");
        }


        [HttpPost]
        public ActionResult AddSubCategory(CategoryModel model)
        {
            if (!string.IsNullOrEmpty(model.Category) && !string.IsNullOrEmpty(model.SubCategory))
                new CategoryRepository().AddCategory(model);
            return RedirectToAction("Index", "Editor");
        }
        

        [HttpGet]
        public JsonResult GetSubCategories(string Category)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            CategoryRepository repo = new CategoryRepository();
            result.Data = repo.GetSubCategory(Category);
            return result;
        }
    }
}