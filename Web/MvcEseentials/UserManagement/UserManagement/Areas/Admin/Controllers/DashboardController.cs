using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserManagement.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController()
        {
            UserManagement.Models.SessionWrapper.IsAdmin();
        }
        // GET: /Admin/Dashboard/
        public ActionResult Index()
        {
            return View();
        }
	}
}