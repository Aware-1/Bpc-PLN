using System.Globalization;

namespace Application.Convertor
{
    public static class DataConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
        public static DateTime ToMiladi(this string ts)
        {
            var spliteDate = ts.Replace("-", "/").GetEnglishNumbers().Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime currentDate = new DateTime(year, month, day, new PersianCalendar());
            return currentDate;
        }
        public static string GetEnglishNumbers(this string s)
        {
            return s.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2")
                .Replace("۳", "3").Replace("۴", "4").Replace("۵", "5")
                .Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        }


        private static string ToPersianNumber(this object value)
        {
            if (value == null) return "";
            var str = value.ToString();
            return str
                .Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
               .Replace("9", "۹");

        }

    }
}
