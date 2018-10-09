using System;

namespace CubicleJockey.StringExtensions
{
    public static class Enums
    {
        /// <summary>
        /// Converts a string into a given enum.
        /// </summary>
        /// <typeparam name="TEnum">Enum Type to create if a match is found.</typeparam>
        /// <param name="value">String value to convert into an Enum</param>
        /// <param name="ignoreCase">Whether or not to ignore case which matching.</param>
        /// <returns>Expected Enum Type</returns>
        public static TEnum? ToEnum<TEnum>(this string value, bool ignoreCase = false) where TEnum : struct
        {
            var isValid = Enum.TryParse(value, ignoreCase, out TEnum result);
            if (!isValid) { return null; }
            return result;
        }
    }
}
