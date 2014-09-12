using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp
{
    class Test
    {
        public static void Main()
        {
            Model.Student student = new Model.Student();
          student.Id = 3;
          /*student.Name = "Jayesh patel";
          student.Dob = DateTime.Parse("1/02/1990");*/
          Console.WriteLine("Searching data... Result : "+Model.studentdao.findby(student));
           
            
        }
      
       
    }
}
