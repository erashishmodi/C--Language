using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieApp.Util
{
    public class CookieWrapper
    {
        public static void CreateCookie(String key, String Value)
        {
            HttpCookie c = new HttpCookie(key,Value);
            c.Path = "/";
            c.Expires = DateTime.Now.AddDays(7);
            HttpContext.Current.Response.Cookies.Add(c);
        }

        public static String ReadCookie(String Key)
        {
            String Value = "";
            if (HttpContext.Current.Request.Cookies[Key] != null)
                Value = HttpContext.Current.Request.Cookies[Key].Value;
            return Value;
        }

        public static void DeleteCookie(String Key)
        {
            HttpCookie c= new HttpCookie(Key,"");
            c.Path = "/";
            c.Expires = DateTime.Now.AddSeconds(-1);
            HttpContext.Current.Response.Cookies.Add(c);
        }
    }
}