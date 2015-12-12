using SingleViewCrudoperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingleViewCrudoperation.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbEntities db = new EmployeeDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["EmployeeList"] = db.Employees.ToList();
            return View(new EmployeeViewModel());
        }
        [HttpPost]
        public ActionResult Index(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
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
            ViewData["EmployeeList"]= db.Employees.ToList();
            return View(model);
        }
        public ActionResult Edit(int ? id)
        {
            ViewData["EmployeeList"] = db.Employees.ToList();
            if (id == null) return View("Index");
            var search = db.Employees.FirstOrDefault(x=>x.EmployeeId==id);
            if (search == null) return View("Index");
            return View("Index",new EmployeeViewModel {
                EmployeeId=search.EmployeeId,
                EmployeeName=search.EmployeeName,
                EmployeeEmail=search.EmployeeEmail,
                IdDeleted=search.IsDeleted??false
            });   
        }
    }
}