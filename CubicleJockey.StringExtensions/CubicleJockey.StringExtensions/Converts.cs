using System;

namespace CubicleJockey.StringExtensions
{
    public static class Converts
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
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException($"Type {nameof(TEnum)} must be of type {typeof(Enum).FullName}");
            }

            var isValid = Enum.TryParse(value, ignoreCase, out TEnum result);
            if (!isValid) { return null; }
            return result;
        }

        /// <summary>
        /// Convert string to boolean.
        ///
        /// Values [True, true, False, false, Yes, yes, No, No, Y, y, N, n, 1, 0]
        /// </summary>
        /// <param name="self">A String</param>
        /// <returns>Returns a boolean if valid.</returns>
        public static bool ToBoolean(this string self)
        {
            const string INVALID = "Invalid Boolean: Accepted Values: [True, true, False, false, Yes, yes, No, no, Y, y, N, n, 1, 0]";

            if (string.IsNullOrWhiteSpace(self)) { throw new ArgumentException(INVALID); }

            var toCheck = self.ToLower().Trim();

            switch (toCheck)
            {
                case "false": return false;
                case "true": return true;
                case "no": return false;
                case "yes": return true;
                case "y": return true;
                case "n": return false;
                case "0": return false;
                case "1": return true;

                default:
                    throw new ArgumentException(INVALID);
            }
        }

        #region Unsigned Integers

        //public static ushort ToUnsignedShort(this string self)
        //{
        //    Convert.tou
        //}

        #endregion Unsigned Integers
    }
}
