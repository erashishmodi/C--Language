using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SingleViewCrudoperation.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Required, Display(Name = "Employee Name")]
        public String EmployeeName { get; set; }
        [Required, Display(Name = "Employee Email"),EmailAddress]
        public String EmployeeEmail { get; set; }
        public bool IdDeleted { get; set; }
    }
}