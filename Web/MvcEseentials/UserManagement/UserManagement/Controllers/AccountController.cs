using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class AccountController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegistrationViewModel { });
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel userModel)
        {
            if(ModelState.IsValid){
                DateTime today=DateTime.Now;
                UserMaster user = new UserMaster
                {
                    UserFirstName=userModel.FirstName,
                    UserLastName=userModel.LastName,
                    UserMiddleName=userModel.MiddleName,
                    UserEmail=userModel.EmailAddress,
                    UserMobile=userModel.MobileNumber,
                    Address=userModel.Address,
                    UserPassword=userModel.Password,
                    RoleId=2,
                    IsActive=true,
                    IsDeleted=false,
                    DateCreated=today,
                    DateModified=today
                };
                db.UserMasters.Add(user);
                db.SaveChanges(); 
                user.UniqueUserId = "U" + today.Year.ToString() + user.RoleId.ToString() + user.UserId;                                   
                db.SaveChanges();
                TempData["SuccessMessage"] = "Thank you for regestration.";
                ModelState.Clear();
                return View(new RegistrationViewModel { });
            }
            TempData["ErrorMessage"] = "Please enter required fields.";
            return View(userModel);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel { });
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var searchUser = db.UserMasters
                    .Where(x => x.UserEmail == loginModel.UserEmail
                        && x.UserPassword == loginModel.Password
                        && x.IsActive == true
                        ).FirstOrDefault();
                if (searchUser != null)
                {
                    SessionWrapper.UserName = searchUser.UserFirstName;
                    SessionWrapper.UserId = searchUser.UserId;
                    SessionWrapper.UserRole = searchUser.RoleId??0;
                    var userModule = db.UserModuleMappingMasters
                        .Where(x => x.UserId == searchUser.UserId).ToList();
                    foreach(var module in userModule)
                    {
                        SessionWrapper.UserModuleList.Add(module.ModuleId??0);
                    }
                    switch(searchUser.RoleId??0){
                        case 1: Response.Redirect("~/Admin/dashboard");
                            break;
                        case 2: Response.Redirect("~/Manager/DashBoard/");
                            break;
                        default: Response.Redirect("~/account/login");
                            break;
                    }
                }
                TempData["ErrorMessage"] = "User name /Password not matched.";
                return View(loginModel);
            }
            else
            {
                TempData["ErrorMessage"] = "Please enter your credentials.";
                return View(loginModel);
            }
        }
        public void Logout()
        {
            UserManagement.Models.SessionWrapper.Logout();
        }
	}
}