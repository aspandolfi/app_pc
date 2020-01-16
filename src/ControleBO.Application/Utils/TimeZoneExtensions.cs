using System;

namespace ControleBO.Application.Utils
{
    public static class TimeZoneExtensions
    {
        private static readonly TimeZoneInfo _timeInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        public static DateTime ConvertToLocalTime(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, _timeInfo);
        }
    }
}
