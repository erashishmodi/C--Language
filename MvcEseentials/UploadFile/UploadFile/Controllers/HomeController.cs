using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            if(file!=null)
            {
                
                var path = Server.MapPath("~/Files/"+file.FileName);
                file.SaveAs(path);
                ViewBag.Message = file.FileName + " of " + file.ContentType + " type and " + file.ContentLength + " of size is uploaded";                
            }
           
            return View();
        }

        [HttpGet]
        public ActionResult Addcat

    }
}
