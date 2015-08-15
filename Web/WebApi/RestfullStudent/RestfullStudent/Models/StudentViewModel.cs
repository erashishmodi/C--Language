using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestfullStudent.Models
{
    public class StudentViewModel
    {
        public int ? Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}