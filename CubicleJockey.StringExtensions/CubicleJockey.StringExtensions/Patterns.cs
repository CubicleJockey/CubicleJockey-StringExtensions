using System;
using System.Collections.Generic;
using System.Net.Mail;
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

        /// <summary>
        /// Checks if string is a valid email.
        /// Rules are based on MailAddress object.
        /// <remarks>https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress?view=netstandard-2.0</remarks>
        /// </summary>
        /// <param name="self">A String</param>
        /// <returns>Whether or not a string is a valid email.</returns>
        public static bool IsEmail(this string self)
        {
            var isEmail = true;
            try
            {
                new MailAddress(self);
            }
            catch (Exception) { isEmail = false; }

            return isEmail;
        }

        /// <summary>
        /// Checks if a string meets the minimum length.
        /// </summary>
        /// <param name="self">A String</param>
        /// <param name="minimum">Minimum length</param>
        /// <returns>Whether or not string meets the minimum.</returns>
        public static bool IsMinLength(this string self, int minimum)
        {
            return self.Length >= minimum;
        }

        /// <summary>
        /// Checks if a string meets the maximum length.
        /// </summary>
        /// <param name="self">A String</param>
        /// <param name="maximum">Maximum length</param>
        /// <returns>Whether or not string meets the maximum.</returns>
        public static bool IsMaxLength(this string self, int maximum)
        {
            return self.Length <= maximum;
        }

        /// <summary>
        /// Checks if a string meets the minimum and maximum length.
        /// </summary>
        /// <param name="self">A String</param>
        /// <param name="minimum">Minimum length</param>
        /// <param name="maximum">Maximum length</param>
        /// <returns>Whether or not the string meets the minimum and maximum.</returns>
        public static bool IsLengthBetween(this string self, int minimum, int maximum)
        {
            return self.IsMinLength(minimum) && self.IsMaxLength(maximum);
        }
    }
}
