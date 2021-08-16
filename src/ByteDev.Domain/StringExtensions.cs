using System;
using System.Text.RegularExpressions;

namespace ByteDev.Domain
{
    internal static class StringExtensions
    {
        public static string RemoveWhiteSpace(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            return Regex.Replace(source, @"\s+", "");
        }

        public static int FirstDigits(this string source, int numberOfDigits)
        {
            return Convert.ToInt32(source.Substring(0, numberOfDigits));
        }

        public static bool IsLengthBetween(this string source, int from, int to)
        {
            return source.Length >= from && source.Length <= to;
        }

        public static bool ContainsOnlyDigits(this string source)
        {
            var regEx = new Regex(@"^[0-9]+$");

            return regEx.IsMatch(source);
        }

        public static char SafeGetChar(this string source, int index, char defaultChar = '\0')
        {
            if (index < 0 || index >= source.Length)
                return defaultChar;

            return source[index];
        }
    }
}