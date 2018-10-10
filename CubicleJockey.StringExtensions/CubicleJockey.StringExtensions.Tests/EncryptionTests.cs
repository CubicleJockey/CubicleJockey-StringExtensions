using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CubicleJockey.StringExtensions.Tests
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void ToBase64String_DefaultEncoding()
        {
            //Arrange
            const string EXPECTED = "VGVzdCBTdHJpbmc=";
            const string TOCONVERT = "Test String";

            //Act
            var result = TOCONVERT.ToBase64();

            //Assert
            result.Should().Be(EXPECTED);
        }

        [TestMethod]
        public void ToBase64String_NonDefaultEncoding()
        {
            //Arrange
            const string EXPECTED = "VABlAHMAdAAgAFMAdAByAGkAbgBnAA==";
            const string TOCONVERT = "Test String";

            //Act
            var result = TOCONVERT.ToBase64(Encoding.Unicode);

            //Assert
            result.Should().Be(EXPECTED);
        }
    }
}
