using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            const string VALUE = "This8Value17MayHave6Digits";

            //Arrange
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
    }
}
