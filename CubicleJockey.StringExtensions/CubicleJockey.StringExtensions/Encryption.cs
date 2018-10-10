using System;
using System.Text;

namespace CubicleJockey.StringExtensions
{
    public static class Encryption
    {
        public static string ToBase64(this string self, Encoding encoding = null)
        {
            if (encoding == null) { encoding = Encoding.UTF8; }

            var bytes = encoding.GetBytes(self);
            return Convert.ToBase64String(bytes);
        }
    }
}
