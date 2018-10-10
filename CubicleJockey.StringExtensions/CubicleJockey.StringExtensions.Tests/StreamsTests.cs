using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace CubicleJockey.StringExtensions.Tests
{
    [TestClass]
    public class StreamsTests
    {
        private static readonly FileInfo file;

        static StreamsTests()
        {
            var fileAndPath = Path.Combine(Directory.GetCurrentDirectory(), "WriteStringToFileTest.txt");
            file = new FileInfo(fileAndPath);

            DeleteFile();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DeleteFile();
        }

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

        [TestMethod]
        public void ToMemoryStreamDefaultEncoding()
        {
            TestMemoryStreamExtension();
        }

        [TestMethod]
        public void ToMemoryStreamNonDefaultEncoding()
        {
            TestMemoryStreamExtension(Encoding.Unicode);
        }

        [TestMethod]
        public void WriteStringToFile()
        {
            const string TEXT = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit";

            file.Refresh();
            file.Exists.Should().BeFalse();

            TEXT.ToFile(file.FullName);

            file.Refresh();
            file.Exists.Should().BeTrue();

            var content = File.ReadAllText(file.FullName);
            content.Should().Be(TEXT);
        }

        [TestMethod]
        public void WriteStringToFileViaFileInfo()
        {
            const string TEXT = "Per Aspera Ad Inferi. May all your dreams come true.";

            file.Refresh();
            file.Exists.Should().BeFalse();

            TEXT.ToFile(file.FullName);

            file.Refresh();
            file.Exists.Should().BeTrue();

            var content = File.ReadAllText(file.FullName);
            content.Should().Be(TEXT);
        }

        #region Helper Methods

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

        private static void TestMemoryStreamExtension(Encoding encoding = null)
        {
            //Arrange
            const string WORKSTRING = "I am a string to be turned into a memory stream.";

            //Act
            var memoryStreamInfo = encoding == null ? WORKSTRING.ToMemoryStream() : WORKSTRING.ToMemoryStream(encoding);
            var expectedEncoding = encoding ?? Encoding.UTF8;

            //Assert
            memoryStreamInfo.Should().NotBeNull();
            memoryStreamInfo.Encoding.Should().Be(expectedEncoding);
            memoryStreamInfo.MemoryStream.Should().NotBeNull();

            var result = expectedEncoding.GetString(memoryStreamInfo.MemoryStream.ToArray());

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be(WORKSTRING);
        }

        private static void DeleteFile()
        {
            file.Refresh();
            if (file.Exists)
            {
                file.Delete();
            }
        }

        #endregion Helper Methods
    }
}
