using SpaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        SpaDbEntities db = new SpaDbEntities();
        public ActionResult Index()
        {
            ViewBag.ProductList = db.Products.ToList();           
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            SessionWrapper.SignOut();
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var search = db.Logins.Where(x => x.UserEmail == model.UserEmail && x.IsDeleted==false).FirstOrDefault();
                if(search!=null)
                {
                    if (search.IsActive.Value)
                    {
                        if (System.Web.Helpers.Crypto.VerifyHashedPassword(search.UserPass, model.UserPass))
                        {
                            SessionWrapper.UserRole = search.Role.RoleName;
                            SessionWrapper.Username = search.UserEmail;
                            SessionWrapper.UserId = search.UserId;

                            search.DateLastLogin = DateTime.Now;
                            db.SaveChanges();

                            switch(search.RoleId)
                            {
                                case 1: return Redirect("~/Admin/Dashboard");
                                case 2:
                                    return Redirect("~/Branch/Dashboard");
                                case 3:
                                    return Redirect("~/Emp/Dashboard");
                                case 4:
                                    return Redirect("~/Client/Dashboard");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "verify";
                    }
                }
                else
                {
                    ViewBag.Message = "invalid";
                }
            }
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var search = db.Logins.Where(x => x.UserEmail == model.UserEmail).FirstOrDefault();
                if (search != null)
                {
                    ViewBag.Message = "Sorry! Email you've entered is used by someone else. Re-enter new email";
                }
                else
                {
                    string plainPassword = model.UserPass;
                    string hashPassword = System.Web.Helpers
                                                .Crypto.HashPassword(plainPassword);

                    db.Logins.Add(new Login 
                    { 
                        UserEmail = model.UserEmail,
                        UserPass = hashPassword,
                        RoleId = 4,
                        DateCreated  = DateTime.Now,
                        IsActive = false,
                        IsDeleted = false
                    });
                    db.SaveChanges();
                    ViewBag.Message = "Thank you. An email is sent for verification. Please check your mailbox";
                }
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Recover()
        {
            return View(new RecoverViewModel());
        }
        [HttpPost]
        public ActionResult Recover(RecoverViewModel model)
        {
            return View(model);
        }
    }
}