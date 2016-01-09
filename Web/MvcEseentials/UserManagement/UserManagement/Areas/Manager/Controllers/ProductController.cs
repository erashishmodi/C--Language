using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Areas.Manager.Models;

namespace UserManagement.Areas.Manager.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {
            UserManagement.Models.SessionWrapper.IsManager();
            UserManagement.Models.SessionWrapper.CheckModuleRight(2);
        }
        // GET: /Manager/Product/
        DatabaseEntities db = new DatabaseEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductModel { });
        }
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                ProductMaster product = new ProductMaster();
                product.CategoryId = productModel.CategoryId;
                product.ProductName = productModel.ProductName;
                product.Description = productModel.ProductDescription;
                product.IsActive = true;
                product.IsDelete = false;
                product.DateCreated = DateTime.Now;
                db.ProductMasters.Add(product);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Product detail added successfully.";
                ModelState.Clear();
                return View(new ProductModel { });
            }
            TempData["ErrorMessage"] = "Please enter required fields.";
            return View(productModel);
        }
	}
}