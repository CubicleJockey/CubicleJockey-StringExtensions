using System;
using System.Collections.Generic;
using System.Text;

namespace CubicleJockey.StringExtensions
{
    /// <summary>
    /// Actions to perform on a string
    /// </summary>
    public static class Actions
    {
        /// <summary>
        /// Performs an action on each character of a string with no return result.
        /// </summary>
        /// <param name="self">The String</param>
        /// <param name="action">Action to be performed on each character</param>
        public static void ForEach(this string self, Action<char> action)
        {
            foreach (var character in self)
            {
                action(character);
            }
        }

        /// <summary>
        /// Performs a function on each character of a string with an individual result per character.
        /// </summary>
        /// <typeparam name="TFuncResult">Result of function</typeparam>
        /// <param name="self">The String</param>
        /// <param name="function">Function to be performed on each character</param>
        /// <returns>A collection of character results ignoring null returns</returns>
        public static IEnumerable<TFuncResult> ForEach<TFuncResult>(this string self, Func<char, TFuncResult> function)
        {
            IList<TFuncResult> items = new List<TFuncResult>();
            foreach (var character in self)
            {
                var result = function(character);
                if (result == null) { continue; }
                items.Add(result);
            }
            return items;
        }

        /// <summary>
        /// Take a string and reverse it.
        /// </summary>
        /// <param name="self">A String</param>
        /// <returns>Returns the original string in reverse</returns>
        public static string Reverse(this string self)
        {
            ICollection<char> reversedCharacters = new List<char>();
            for (var i = self.Length - 1; i >= 0; i--)
            {
                reversedCharacters.Add(self[i]);
            }
            return string.Join(string.Empty, reversedCharacters);
        }


        /// <summary>
        /// Takes a collection of strings and appends them to current string. Can be done as a flat string or line appended.
        /// </summary>
        /// <param name="self">A String</param>
        /// <param name="lines">Collection of strings to append.</param>
        /// <param name="asAppendLine">Append strings with line return.</param>
        /// <param name="appendWithWhiteSpace">Add whitespace when doing just an Append</param>
        /// <returns>Original string with appended string collection.</returns>
        public static string Append(this string self, IEnumerable<string> lines, bool asAppendLine = false, bool appendWithWhiteSpace = false)
        {
            var sb = new StringBuilder();

            if (asAppendLine) { sb.AppendLine(self); }
            else { sb.Append(self); }

            var leadWith = string.Empty;
            if (appendWithWhiteSpace) { leadWith = " "; }

            var theLines = (string[])lines;
            var lastLine = theLines[theLines.Length - 1];


            foreach (var line in theLines)
            {
                if (asAppendLine && line == lastLine)
                {
                    sb.Append(line);
                    continue;
                }
                if (asAppendLine)
                {
                    sb.AppendLine(line);
                    continue;
                }
                sb.Append($"{leadWith}{line}");
            }
            return sb.ToString();
        }
    }
}
