using System.Globalization;

namespace SaltStacker.Common.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime ConvertFromUtc(this DateTime dateTime, string culture = "Pacific Standard Time")
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(culture);
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, timeZone);
        }

        public static DateTime ConvertFromUtc(this DateTime dateTime)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, timeZone);
        }

        public static string ConvertFromUtcString(this DateTime dateTime, string format = "")
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "yyyy/MM/dd HH:mm:ss";
            }

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, timeZone).ToString(format);
        }

        public static string GetShortDayName(this DayOfWeek day)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            string[] names = culture.DateTimeFormat.AbbreviatedDayNames;
            return names[(int)day];
        }
    }
}
