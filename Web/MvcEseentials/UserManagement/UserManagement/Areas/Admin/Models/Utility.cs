using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Areas.Admin.Models
{
    public class Utility
    {
        private static DatabaseEntities db = new DatabaseEntities();
        public static List<KeyValueModel> GetModulesKeyValue()
        {
            List<KeyValueModel> list = new List<KeyValueModel>();
            foreach(var item in db.ModuleMasters.Where(x=>x.IsActive==true))
            {
                list.Add(new KeyValueModel {
                    Key=item.ModuleId,
                    Value=item.ModuleName
                });
            }
            return list;
        }


    }
}