using RestfullStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfullStudent.Controllers
{  
    public class StudentController : ApiController
    {
        private StudentDbEntities db = new StudentDbEntities();
        // GET: api/Student
        public IEnumerable<StudentViewModel> Get()
        {
            List<StudentViewModel> list = new List<StudentViewModel>();
            foreach(var i in db.Students.ToList()){
                list.Add(new StudentViewModel {Id=i.StudentId,Name=i.StudentName});
            }            
            return list.OrderBy(x=>x.Id);
        }
        // GET: api/Student/5
        public StudentViewModel Get(int id)
        {
            var search = db.Students.FirstOrDefault(x => x.StudentId == id);
            if(search==null)
                return new StudentViewModel { Id=0,Name="N.A" };
            else
                return new StudentViewModel{Id=search.StudentId,Name=search.StudentName};

        }
        // POST: api/Student
        public string Post([FromBody]StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(new Student() { StudentName=student.Name});
                db.SaveChanges();
                return "DATA ADDED SUCCESSFULLY.";
            }
            return "PLEASE ENTER REQUIRED FIELDS.";
        }
        // PUT: api/Student/5
        public void Put([FromBody]StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var search = db.Students.FirstOrDefault(x => x.StudentId == student.Id);
                if(search!=null)
                {
                    search.StudentName = student.Name;
                    db.SaveChanges();
                }
            }
        }
        // DELETE: api/Student/5
        public void Delete(int id)
        {
            var search = db.Students.FirstOrDefault(x => x.StudentId == id);
            if (search != null)
            {
                db.Students.Remove(search);
                db.SaveChanges();
            }
        }
    }
}
