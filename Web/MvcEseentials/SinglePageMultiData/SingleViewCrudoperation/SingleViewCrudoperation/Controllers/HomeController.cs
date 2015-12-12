using SingleViewCrudoperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingleViewCrudoperation.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDbEntities db = new EmployeeDbEntities();
        [HttpGet]
        public ActionResult Index(int ? id)
        {
            ViewData["EmployeeList"] = db.Employees.ToList();
            if (id != null)
            {
                var search = db.Employees.FirstOrDefault(x=>x.EmployeeId==id);
                if (search != null)
                {
                    return View(new EmployeeViewModel
                    {
                        EmployeeId = search.EmployeeId,
                        EmployeeName = search.EmployeeName,
                        EmployeeEmail = search.EmployeeEmail,
                        IdDeleted=search.IsDeleted??false
                    });
                }
            }   
            return View(new EmployeeViewModel());
        }
        [HttpPost]
        public ActionResult Index(EmployeeViewModel employeeModel)
        {           
            if (ModelState.IsValid)
            {
                var search = db.Employees.FirstOrDefault(x=>x.EmployeeId==employeeModel.EmployeeId);
                if (search == null)
                {
                    db.Employees.Add(new Employee
                    {
                        EmployeeName = employeeModel.EmployeeName,
                        EmployeeEmail = employeeModel.EmployeeEmail,
                        IsDeleted=false
                    });
                }
                else
                {
                    search.EmployeeName = employeeModel.EmployeeName;
                    search.EmployeeEmail = employeeModel.EmployeeEmail;
                    search.IsDeleted = employeeModel.IdDeleted;
                }                
                db.SaveChanges();
                ModelState.Clear();
                ViewData["EmployeeList"] = db.Employees.ToList();
                return View(new EmployeeViewModel());
            }
            ViewData["EmployeeList"] = db.Employees.ToList();
            return View(employeeModel);
        }
        [HttpGet]
        public ActionResult Delete(int ? id)
        {
            if(id==null) return RedirectToAction("Index");
            var search = db.Employees.FirstOrDefault(x=>x.EmployeeId==id);
            if (search == null) return RedirectToAction("Index");
            search.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}