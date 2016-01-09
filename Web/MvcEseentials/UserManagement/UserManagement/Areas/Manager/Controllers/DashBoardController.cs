using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserManagement.Areas.Manager.Controllers
{
    public class DashBoardController : Controller
    {
        public DashBoardController()
        {
            UserManagement.Models.SessionWrapper.IsManager();                            
        }
        // GET: /Manager/DashBoard/
        public ActionResult Index()
        {
            return View();
        }
	}
}