using System.IO;
using System.Text;

namespace CubicleJockey.StringExtensions
{
    public static class Streams
    {
        /// <summary>
        /// Converts a string into a Stream
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

        /// <summary>
        /// Converts a string into a MemoryStream
        /// </summary>
        /// <param name="self">A String</param>
        /// <param name="encoding">Encoding style for the stream. Defaults to UTF8 if not provided.</param>
        /// <returns>A MemoryStream and its current encoding</returns>
        public static (MemoryStream MemoryStream, Encoding Encoding) ToMemoryStream(this string self, Encoding encoding = null)
        {
            var memoryStream = new MemoryStream();
            var streamInfo = self.ToStream(encoding);
            streamInfo.Stream.CopyTo(memoryStream);

            return (memoryStream, streamInfo.Encoding);
        }
    }
}
