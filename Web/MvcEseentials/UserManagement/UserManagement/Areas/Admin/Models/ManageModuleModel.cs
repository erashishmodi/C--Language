using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.Areas.Admin.Models
{
    public class ManageModuleModel
    {
        [Required]
        public int UserId { get; set; }
        [Display(Name="Module")]
        public List<int> Modules { get; set; }
        public static IEnumerable<System.Web.Mvc.SelectListItem> GetModuleDroDownList
        {
            get
            {
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    foreach (var module in db.ModuleMasters.ToList())
                        yield return new System.Web.Mvc.SelectListItem
                        {
                            Text = module.ModuleName,
                            Value = module.ModuleId.ToString()
                        };
                }
            }
        }
        public static List<int> GetModuleListByUserId(int UserId)
        {
            List<int> list = new List<int> { 0 };
            using(DatabaseEntities db= new DatabaseEntities())
            {
                foreach(var item in db.UserModuleMappingMasters.Where(x=>x.UserId==UserId).ToList())
                {
                    list.Add(item.ModuleId??0);
                } 
            }
            return list;
        }
       
    }
}