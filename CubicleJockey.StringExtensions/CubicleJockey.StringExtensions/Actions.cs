﻿using System;
using System.Collections.Generic;

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
    }
}
