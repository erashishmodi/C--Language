using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadFile.Models;

namespace UploadFile.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null)
            {

                var path = Server.MapPath("~/Files/" + file.FileName);
                file.SaveAs(path);
                ViewBag.Message = file.FileName + " of " + file.ContentType + " type and " + file.ContentLength + " of size is uploaded";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Addcategory()
        {
            ProductDbEntities db = new ProductDbEntities();
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Addcategory(CategoryModel model)
        {
            var file = Request.Files["poto"];
            ProductDbEntities db = new ProductDbEntities();
            if (file == null)
            {
                ViewBag.Message = "Please select a file";
                return View();
            }
            if (file.ContentType != "image/png")
            {
                ViewBag.Message = "Select .png file";
                return View();
            }
            if(file.ContentLength>50*1024)
            {
                ViewBag.Message = "File shuld be less than 50kb";
                return View();
            }
            Category category = new Category();
            category.Name = model.Name;
            category.Id = model.Id;
            db.Categories.Add(category);
            db.SaveChanges();

            var filename = category.Id + ".png";
            var path = Server.MapPath("~/Files/Images/"+filename);
            file.SaveAs(path);
            ViewBag.Message = "Record Added";
            return View();
        }

    }
}
