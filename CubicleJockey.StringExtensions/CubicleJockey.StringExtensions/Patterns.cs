using System;
using System.Text.RegularExpressions;

namespace CubicleJockey.StringExtensions
{
    public static class Patterns
    {
        public static bool Match(this string value, string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern)) { throw new ArgumentException("Regex pattern cannot be empty.", nameof(pattern)); }

            return Regex.IsMatch(value, pattern);
        }
    }
}
