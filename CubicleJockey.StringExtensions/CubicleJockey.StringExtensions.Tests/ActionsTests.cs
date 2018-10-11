using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CubicleJockey.StringExtensions.Tests
{
    [TestClass]
    public class ActionsTests
    {
        [TestMethod]
        public void ActionForEach()
        {
            //Arrange
            var count = 0;
            const string VALUE = "123456789";

            void DoWork(char character)
            {
                WriteLine($"Counting Character {character}.");
                count++;
            }

            //Act
            VALUE.ForEach(DoWork);

            //Assert
            count.Should().Be(9);
        }

        [TestMethod]
        public void FunctionForEachWithResult()
        {
            //Arrange
            const string VALUE = "This8Value17MayHave6Digits";

            (char Character, bool IsDigit) IsDigit(char character)
            {
                var isDigit = char.IsDigit(character);
                return (character, isDigit);
            }

            //Act
            var result = VALUE.ForEach(IsDigit).ToArray();

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Length.Should().Be(VALUE.Length);

            var nonDigitsCount = result.Count(item => !item.IsDigit);
            nonDigitsCount.Should().Be(22);

            var digitCount = result.Count(item => item.IsDigit);
            digitCount.Should().Be(4);
        }

        [TestMethod]
        public void Reverse()
        {
            const string WORD = "André";

            var reversedWord = WORD.Reverse();

            reversedWord.Should().NotBeNullOrWhiteSpace();
            reversedWord.Should().NotBe(WORD);
            reversedWord.Should().Be("érdnA");
        }

        [TestMethod]
        public void Append()
        {
            //Arrange
            const string ORIGINAL = "Original Line.";
            IEnumerable<string> lines = new[] { "AppendedItem1", "AppendedItem2" };

            //Act
            var result = ORIGINAL.Append(lines);

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Original Line.AppendedItem1AppendedItem2");
        }

        [TestMethod]
        public void AppendWithSpaces()
        {
            //Arrange
            const string ORIGINAL = "Original Line.";
            IEnumerable<string> lines = new[] { "AppendedItem1", "AppendedItem2" };

            //Act
            var result = ORIGINAL.Append(lines, appendWithWhiteSpace: true);

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Original Line. AppendedItem1 AppendedItem2");
        }

        [TestMethod]
        public void AppendWithLineReturns()
        {
            //Arrange
            const string ORIGINAL = "Original Line.";
            IEnumerable<string> lines = new[] { "AppendedLine1", "AppendedLine2" };
            const string EXPECTED = @"Original Line.
AppendedLine1
AppendedLine2";

            //Act
            var result = ORIGINAL.Append(lines, true);

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be(EXPECTED);
        }
    }
}
