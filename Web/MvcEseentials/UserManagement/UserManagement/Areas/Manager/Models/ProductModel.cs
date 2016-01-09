using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.Areas.Manager.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Please select the category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Product")]
        [StringLength(100, ErrorMessage = "Product name should not contain more than 100 alphabates.")]
        public string ProductName { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Product description should not contain more than 500 alphabates.")]
        public string ProductDescription { get; set; }

    }
}