﻿using FluentAssertions;
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

        [TestMethod]
        public void SplitOnCamelCasing()
        {
            const string WORDS = "IAmJamesHowlett";

            var words = WORDS.SplitCamelCase().ToArray();

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
            const string WORDS = "IAmJamesHowlett";

            var humanWorthy = WORDS.CamelCaseToHumanCase();

            humanWorthy.Should().NotBeNullOrWhiteSpace();
            humanWorthy.Should().Be("I Am James Howlett");
        }
    }
}
