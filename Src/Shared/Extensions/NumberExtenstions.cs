using System;
using System.Linq;

namespace Kolpi.Shared.Extentions
{
    public static class Number
    {
        public static bool IsNumber(this string value) => string.IsNullOrWhiteSpace(value) ? false : value.All(char.IsNumber);
        public static string FormatAsCommaSeparated(this int value) => value.ToString("N0");
        public static int ToInt(this string value) => IsNumber(value) ? int.Parse(value): default;
    }
}