using SpaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaSystem.Controllers
{
    public class MyAuthoriseAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var array = Roles.Split(',');
            return array.Contains(SessionWrapper.UserRole)
                && SessionWrapper.UserId!=0;
           // return Roles.Equals(SessionWrapper.UserRole);
        }
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("~/Home/Login");                                               
        }
    }
}