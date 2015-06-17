using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CookieApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {return Content("Home Page");}
        public void Create()
        {CookieApp.Util.CookieWrapper.CreateCookie("UserName","Ashish Modi");}
        public void Delete()
        {CookieApp.Util.CookieWrapper.DeleteCookie("UserName");}
        public ActionResult Read()
        {return Content(CookieApp.Util.CookieWrapper.ReadCookie("UserName"));}
    }
}