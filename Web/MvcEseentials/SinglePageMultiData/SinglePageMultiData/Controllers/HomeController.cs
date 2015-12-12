using SinglePageMultiData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageMultiData.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(IEnumerable<Category> categoryList)
        {
            //Code for save data into the database.
            return Json(categoryList, JsonRequestBehavior.AllowGet);
        }
    }
}