using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.Areas.Manager.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Category name should not contain more than 100 alphabates.")]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [StringLength(500, ErrorMessage = "Category name should not contain more than 500 alphabates.")]
        [Display(Name = "Description")]
        public string CategoryDescription { get; set; }

        public static IEnumerable<System.Web.Mvc.SelectListItem> GetCategoryDropdownList
        {
            get
            {
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    foreach (var category in db.CategoryMasters.Where(x => x.IsActive == true).ToList())
                    {
                        yield return new System.Web.Mvc.SelectListItem
                        {
                            Text=category.CategoryName,
                            Value=category.CategoryId.ToString()
                        };
                    }
                }
            }
        }

    }
}