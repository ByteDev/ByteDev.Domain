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
    }
}