using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CubicleJockey.StringExtensions
{
    public static class Patterns
    {
        /// <summary>
        /// Take a regex matching pattern and test against self.
        /// </summary>
        /// <param name="self">A String</param>
        /// <param name="pattern">Regex pattern to test</param>
        /// <returns></returns>
        public static bool Match(this string self, string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern)) { throw new ArgumentException("Regex pattern cannot be empty.", nameof(pattern)); }

            return Regex.IsMatch(self, pattern);
        }

        /// <summary>
        /// Take a string and split it based on Camel Casing.
        /// </summary>
        /// <param name="self">A String</param>
        /// <returns>A collection of words split based on Camel Case</returns>
        public static IEnumerable<string> SplitCamelCase(this string self)
        {
            const string PATTERN = @"[A-Z][a-z]*|[a-z]+|\d+";
            var matches = Regex.Matches(self, PATTERN);

            ICollection<string> words = new List<string>();
            foreach (Match match in matches)
            {
                words.Add(match.Value);
            }
            return words;
        }

        /// <summary>
        /// Take a camel cased string and split it for human consumption.
        /// </summary>
        /// <param name="self">A String</param>
        /// <returns>A string spaced for human consumption</returns>
        public static string CamelCaseToHumanCase(this string self)
        {
            var words = self.SplitCamelCase();
            var humanCased = string.Join(" ", words);
            return humanCased;
        }
    }
}
