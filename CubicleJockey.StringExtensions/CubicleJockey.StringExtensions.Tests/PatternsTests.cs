using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CubicleJockey.StringExtensions.Tests
{
    [TestClass]
    public class PatternsTests
    {
        //Format: YYYY-MM-DD
        private const string DATE_REGEX = @"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))";

        [TestMethod]
        public void IsAPatternMatch()
        {
            //Arrange
            const string DATE = "2018-07-28";

            //Act/Assert
            DATE.Match(DATE_REGEX).Should().BeTrue();
        }

        [TestMethod]
        public void IsNotAPatternMatch()
        {
            const string DATE = "12-31-2001";

            DATE.Match(DATE_REGEX).Should().BeFalse();
        }

        [DataRow("")]
        [DataRow(default(string))]
        [DataRow("      ")]
        [DataTestMethod]
        public void PatternIsEmpty(string pattern)
        {
            //Arrange
            Action call = () => "ValueNotImportant".Match(pattern);

            //Act/Assert
            call.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Regex pattern cannot be empty.{Environment.NewLine}Parameter name: pattern");
        }

        [TestMethod]
        public void SplitOnCamelCasing()
        {
            //Arrange
            const string WORDS = "IAmJamesHowlett";

            //Act
            var words = WORDS.SplitCamelCase().ToArray();

            //Assert
            words.Should().NotBeNullOrEmpty();
            words.Length.Should().Be(4);
            words[0].Should().Be("I");
            words[1].Should().Be("Am");
            words[2].Should().Be("James");
            words[3].Should().Be("Howlett");
        }

        [TestMethod]
        public void HumanReadableBasedOnCamelCasing()
        {
            //Arrange
            const string WORDS = "IAmJamesHowlett";

            //Act
            var humanWorthy = WORDS.CamelCaseToHumanCase();

            //Assert
            humanWorthy.Should().NotBeNullOrWhiteSpace();
            humanWorthy.Should().Be("I Am James Howlett");
        }


        [DataRow(default(string))]
        [DataRow("")]
        [DataRow("     ")]
        [DataRow("someemail_hotmail.com")]
        [DataRow("AlmostAnEmail@")]
        [DataTestMethod]
        public void IsEmailInvalid(string email)
        {
            email.IsEmail().Should().BeFalse();
        }

        [DataRow("james.howlett@yopmail.com")]
        [DataRow("andredavis@yahoo.com")]
        [DataRow("i_luv_2_swim@comcast.net")]
        [DataTestMethod]
        public void IsEmailValid(string email)
        {
            email.IsEmail().Should().BeTrue();
        }

        [DataRow("")]
        [DataRow("a")]
        [DataRow("ab")]
        [DataRow("abc")]
        [DataTestMethod]
        public void IsMinLengthInvalid(string word)
        {
            word.IsMinLength(4).Should().BeFalse();
        }

        [DataRow("abcd")]
        [DataRow("abcde")]
        [DataRow("abcdef")]
        [DataRow("abcdefg")]
        [DataRow("abcdefgh")]
        [DataTestMethod]
        public void IsMinLengthValid(string word)
        {
            word.IsMinLength(4).Should().BeTrue();
        }

        [DataRow("abcd")]
        [DataRow("abcde")]
        [DataRow("abcdef")]
        [DataRow("abcdefg")]
        [DataRow("abcdefgh")]
        [DataTestMethod]
        public void IsMaxLengthInvalid(string word)
        {
            word.IsMaxLength(3).Should().BeFalse();
        }

        [DataRow("a")]
        [DataRow("ab")]
        [DataRow("abc")]
        [DataTestMethod]
        public void IsMaxLengthValid(string word)
        {
            word.IsMaxLength(3).Should().BeTrue();
        }

        [DataRow("12")]
        [DataRow("123456")]
        [DataTestMethod]
        public void IsLengthBetweenInvalid(string word)
        {
            word.IsLengthBetween(3, 5).Should().BeFalse();
        }

        [DataRow("123")]
        [DataRow("1234")]
        [DataRow("1235")]
        [DataTestMethod]
        public void IsLengthBetweenValid(string word)
        {
            word.IsLengthBetween(3, 5).Should().BeTrue();
        }
    }
}
