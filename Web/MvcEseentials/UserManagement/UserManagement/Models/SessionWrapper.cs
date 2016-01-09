using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class SessionWrapper
    {
        public static String UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] != null)
                    return HttpContext.Current.Session["UserName"].ToString();
                return null;
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] != null)
                    return Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                return 0;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        } 
        public static int UserRole
        {
            get
            {
                if (HttpContext.Current.Session["UserRole"] != null)
                    return Convert.ToInt32(HttpContext.Current.Session["UserRole"]);
                return 0;
            }
            set
            {
                HttpContext.Current.Session["UserRole"] = value;
            }
        }
        public static void IsManager()
        {
            if (UserRole != 2)
                HttpContext.Current.Response.Redirect("~/Account/Login");
        }
        public static void IsAdmin()
        {
            if (UserRole != 1)
                HttpContext.Current.Response.Redirect("~/Account/Login");
        }
        public static List<int> UserModuleList
        {
            get
            {
                List<int> userModuleList = new List<int>();
                if (HttpContext.Current.Session["UserModuleList"] == null)
                    HttpContext.Current.Session["UserModuleList"] = new List<int>();
               // else
                    return HttpContext.Current.Session["UserModuleList"] as List<int>;
                //return userModuleList;
            }
        }
        public static void CheckModuleRight(int moduleId)
        {
            if (!UserModuleList.Contains(moduleId))
            {
                System.Web.Mvc.Controller controller = new UserManagement.Controllers.HomeController();
                controller.TempData["ErrorMessage"] = "Insufficient rigth.";
                HttpContext.Current.Response.Redirect("~/Manager/DashBoard/");
            }
        }
        public static void Logout()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("~/Account/Login");
        }
    }
}