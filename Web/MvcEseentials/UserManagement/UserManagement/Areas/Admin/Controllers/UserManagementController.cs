using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Areas.Manager;
using UserManagement.Areas.Admin.Models;

namespace UserManagement.Areas.Admin.Controllers
{
    public class UserManagementController : Controller
    {
        public UserManagementController()
        {
            UserManagement.Models.SessionWrapper.IsAdmin();
        }
        // GET: /Admin/UserManagement/
        DatabaseEntities db = new DatabaseEntities();
        public ActionResult Index()
        {
            return View(db.UserMasters.Where(x=>x.IsActive==true && x.RoleId==2).ToList());
        }
        [HttpGet]
        public ActionResult ManageModules(int? userId)
        {
            if (userId != null)
            {
                //Passing the list of modules to the view.
                ViewBag.ModuleList = Models.Utility.GetModulesKeyValue();
                //Passinng the list of module which user has rigth.
                ViewBag.UserModules = Models.ManageModuleModel.GetModuleListByUserId(userId ?? 0);
                return View(new ManageModuleModel {UserId=userId??0});
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ManageModules(ManageModuleModel manageModel)
        {
            if (ModelState.IsValid)
            {
                var searchRecord = db.UserModuleMappingMasters
                    .Where(record => record.UserId == manageModel.UserId).ToList();
                if (searchRecord != null)
                {
                    db.UserModuleMappingMasters.RemoveRange(searchRecord);
                    db.SaveChanges();
                }
                if (manageModel.Modules != null)
                {
                    foreach (var module in manageModel.Modules as List<int>)
                    {
                        db.UserModuleMappingMasters
                            .Add(new UserModuleMappingMaster
                            {
                                IsActive = true,
                                UserId = manageModel.UserId,
                                ModuleId = module,
                                DateCreated = DateTime.Now,
                                CreatedBy = UserManagement.Models.SessionWrapper.UserId
                            });
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");            
        }
	}
}