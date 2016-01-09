using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Areas.Manager.Models;

namespace UserManagement.Areas.Manager.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController()
        {
            UserManagement.Models.SessionWrapper.IsManager();
            UserManagement.Models.SessionWrapper.CheckModuleRight(1);
        }
        // GET: /Manager/Category/
        DatabaseEntities db = new DatabaseEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CategoryModel { });
        }
        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                CategoryMaster category = new CategoryMaster();
                category.CategoryName = categoryModel.CategoryName;
                category.Description = categoryModel.CategoryDescription;
                category.IsActive = true;
                category.IsDelete = false;
                category.DateCreated = DateTime.Now;
                db.CategoryMasters.Add(category);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Category added successfully.";
                ModelState.Clear();
                return View(new CategoryModel { });
            }
            TempData["ErrorMessage"] = "Please enter required fields.";
            return View(categoryModel);
        }
	}
}