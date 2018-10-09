using System.IO;
using System.Text;

namespace CubicleJockey.StringExtensions
{
    public static class Streams
    {
        /// <summary>
        /// Convert a string to a Stream
        /// </summary>
        /// <param name="self">A String</param>
        /// <param name="encoding">Encoding style for the stream. Defaults to UTF8 if not provided.</param>
        /// <returns>A Stream and its current encoding</returns>
        public static (Stream Stream, Encoding Encoding) ToStream(this string self, Encoding encoding = null)
        {
            if (encoding == null) { encoding = Encoding.UTF8; }
            var bytes = encoding.GetBytes(self);
            return (new MemoryStream(bytes), encoding);
        }
    }
}
