using System;

namespace Kolpi.Shared.Extentions
{
    public static class DateTimeExtensions
    {
        public static string Relativize(this DateTime dateFrom, DateTime dateTo = default)
        {
            // If date instance is default
            if (dateFrom == default)
                return string.Empty;

            // If nothing sent to dateTo, user is asking relative to current time
            if (dateTo == default)
                dateTo = DateTime.UtcNow;

            bool isFuture = false;
            if (dateFrom > dateTo)
                isFuture = true;

            if (isFuture)
            {
                dateTo = dateFrom;
                dateFrom = DateTime.UtcNow;
            }

            TimeSpan duration = dateTo.Subtract(dateFrom);

            string countPhrase;
            int daysCount = duration.Days;
            if (daysCount > 0)
            {   
                countPhrase = $"{daysCount} {(daysCount == 1 ? "day" : "days")}";
                return isFuture ? "After " + countPhrase : countPhrase + " ago";
            }

            int hoursCount = duration.Hours;
            if (hoursCount > 0)
            {
                countPhrase = $"{hoursCount} {(hoursCount == 1 ? "hour" : "hours")}";
                return isFuture ? "After " + countPhrase : countPhrase + " ago";
            }

            int minsCount = duration.Minutes;
            if (minsCount > 0)
            {
                countPhrase = $"{minsCount} {(minsCount == 1 ? "minute" : "minutes")}";
                return isFuture ? "After " + countPhrase : countPhrase + " ago";
            }

            int secsCount = duration.Seconds;
            if (secsCount > 0)
            {
                countPhrase = $"{secsCount} {(secsCount == 1 ? "second" : "seconds")}";
                return isFuture ? "After " + countPhrase : countPhrase + " ago";
            }

            return "Just now";
        }
    }
}
