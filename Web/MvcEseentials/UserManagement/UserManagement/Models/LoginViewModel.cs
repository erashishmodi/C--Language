using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter email address.")]
        [Display(Name = "User Email")]
        [EmailAddress]
        public String UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [Display(Name = "Password")]
        public String Password { get; set; } 
    }
}