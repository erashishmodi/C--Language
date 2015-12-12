using SingleViewCrudoperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingleViewCrudoperation.Controllers
{
    public class EmployeeCaseController : Controller
    {
        EmployeeDbEntities db = new EmployeeDbEntities();
        [HttpGet]
        public ActionResult Index(int? id)
        {
            ViewData["EmployeeList"] = db.Employees.ToList();
            if (id != null)
            {
                var search = db.Employees.FirstOrDefault(x => x.EmployeeId == id);
                if (search != null)
                {
                    return View(new EmployeeViewModel
                    {
                        EmployeeId = search.EmployeeId,
                        EmployeeName = search.EmployeeName,
                        EmployeeEmail = search.EmployeeEmail,
                        IdDeleted = search.IsDeleted ?? false
                    });
                }
            }
            return View(new EmployeeViewModel());
        }
        [HttpPost]
        public ActionResult Index(EmployeeViewModel model,String command)
        {
            switch (command)
            {
                case "Create":
                    if(ModelState.IsValid)
                    {
                        db.Employees.Add(new Employee {
                            EmployeeName=model.EmployeeName,
                            EmployeeEmail=model.EmployeeEmail,
                            IsDeleted=model.IdDeleted
                        });
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewData["EmployeeList"] = db.Employees.ToList();
                        return View(new EmployeeViewModel());
                    }
                    else
                    {
                        ViewData["EmployeeList"] = db.Employees.ToList();
                        return View(model);
                    }
                case "Update":
                    if(ModelState.IsValid)
                    {
                        var search = db.Employees.FirstOrDefault(x => x.EmployeeId == model.EmployeeId);
                        if(search!=null)
                        {
                            search.EmployeeName = model.EmployeeName;
                            search.EmployeeEmail = model.EmployeeEmail;
                            search.IsDeleted = model.IdDeleted;
                            db.SaveChanges();
                        }
                        ViewData["EmployeeList"] = db.Employees.ToList();
                        ModelState.Clear();
                        return View(new EmployeeViewModel());
                    }
                    else
                    {
                        ViewData["EmployeeList"] = db.Employees.ToList();
                        return View(model);
                    }

                
                default: return RedirectToAction("Index");
            }
        }
    }
}