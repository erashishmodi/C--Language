using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class RegistrationViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter First Name.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Middle Name.")]
        [Display(Name = "Middle Name")]
        public String MiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address.")]
        [Display(Name = "Emai Address")]
        [EmailAddress(ErrorMessage="Please Enter Valid Email Address.")]
        public String EmailAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number.")]
        [Display(Name = "Mobile Number")]
        public String MobileNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Address.")]
        [Display(Name = "Address")]
        public String Address { get; set; }


        [Required(ErrorMessage = "Please Enter Password.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Please Conform Password.")]
        [Display(Name = "Conform Password")]
        [Compare("Password",ErrorMessage="Password not match with confirm password.")]
        public String ConfirmPassword { get; set; }
            
    }
}