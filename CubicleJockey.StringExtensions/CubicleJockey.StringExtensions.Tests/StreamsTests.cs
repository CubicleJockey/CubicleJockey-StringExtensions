using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace CubicleJockey.StringExtensions.Tests
{
    [TestClass]
    public class StreamsTests
    {
        [TestMethod]
        public void ToStreamDefaultEncoding()
        {
            TestStreamExtension();
        }



        [TestMethod]
        public void ToStreamNonDefaultEncoding()
        {
            TestStreamExtension(Encoding.BigEndianUnicode);
        }

        private static void TestStreamExtension(Encoding encoding = null)
        {
            //Arrange
            const string WORKSTRING = "I am a string to be turned into a stream.";

            //Act
            var streamInfo = encoding == null ? WORKSTRING.ToStream() : WORKSTRING.ToStream(encoding);
            var expectedEncoding = encoding ?? Encoding.UTF8;

            //Assert
            streamInfo.Should().NotBeNull();
            streamInfo.Encoding.Should().Be(expectedEncoding);
            streamInfo.Stream.Should().NotBeNull();

            var memoryStream = new MemoryStream();
            streamInfo.Stream.CopyTo(memoryStream);

            var result = expectedEncoding.GetString(memoryStream.ToArray());

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be(WORKSTRING);
        }
    }
}
