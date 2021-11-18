using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.ComponentsLibrary
{
    public class PersianDate
    {
        public static string NowGetWithSlash
        {
            get
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                DateTime now = DateTime.Now;
                var res = $"{persianCalendar.GetYear(now)}/{persianCalendar.GetMonth(now).ToString("D2")}/{persianCalendar.GetDayOfMonth(now).ToString("D2")}";
                return res;
            }
        }

        public static string GetWithSlash(DateTime dt)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            //DateTime dt = DateTime.Now;
            var res = $"{persianCalendar.GetYear(dt)}/{persianCalendar.GetMonth(dt).ToString("D2")}/{persianCalendar.GetDayOfMonth(dt).ToString("D2")}";
            return res;

        }

        public static DateTime ConvertToGregorian(string persianDate)
        {
            DateTime dt = DateTime.Parse(persianDate, new CultureInfo("fa-IR"));
            return dt;
        }
    }
}
