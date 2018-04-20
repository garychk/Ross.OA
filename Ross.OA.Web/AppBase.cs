using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ross.OA.Web
{
    public class AppBase
    {
        public static bool SetCookie(string strName, string strValue, int days)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.AddDays(days);
                Cookie.Value = strValue;
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static HttpCookie GetCookie(string strName)
        {
            HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies[strName];
            if (Cookie != null)
            {
                return Cookie;
            }
            else
            {
                return null;
            }
        }
        public static string CookieVal(string strName)
        {
            try
            {
                HttpCookie Cookie = HttpContext.Current.Request.Cookies[strName];
                if (Cookie != null)
                {
                    return Cookie.Value;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        public static bool DelCookie(string strName, string domain)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Values.Clear();
                Cookie.Domain = domain;
                Cookie.Expires = DateTime.Now.AddDays(-1000);
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static int GetEmpId()
        {
            if (GetCookie("EmpId") != null)
            {
                return int.Parse(CookieVal("EmpId"));
            }
            else
                return 0;
        }
        public static int GetEmpDeptId()
        {
            if (GetCookie("EmpDeptId") != null)
            {
                return int.Parse(CookieVal("EmpDeptId"));
            }
            else
                return 0;
        }

        public static string DateStringFromNow(DateTime dt)
        {
            TimeSpan
            span = DateTime.Now - dt;
            if (span.TotalDays > 60)
            {
                return dt.ToShortDateString();
            }
            else if (span.TotalDays > 30)
            {
                return "1个月前";
            }
            else if (span.TotalDays > 14)
            {
                return "2周前";
            }
            else if (span.TotalDays > 7)
            {
                return "1周前";
            }
            else if (span.TotalDays > 1)
            {
                return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
            }
            else if (span.TotalHours > 1)
            {
                return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
            }
            else if (span.TotalMinutes > 1)
            {
                return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
            }
            else if (span.TotalSeconds >= 1)
            {
                return string.Format("{0}秒前",
                (int)Math.Floor(span.TotalSeconds));
            }
            else
            {
                return "1秒前";
            }
        }
        public static decimal ToDecimal(object val)
        {
            try
            {
                return Convert.ToDecimal(val);
            }
            catch { return 0; }
        }
    }
}