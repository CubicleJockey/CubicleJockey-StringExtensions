using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            const string DATE = "2018-07-28";

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
            Action call = () => "ValueNotImportant".Match(pattern);

            call.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Regex pattern cannot be empty.{Environment.NewLine}Parameter name: pattern");
        }
    }
}
