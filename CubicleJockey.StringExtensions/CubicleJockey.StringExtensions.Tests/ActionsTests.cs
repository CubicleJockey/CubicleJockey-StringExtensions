using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Console;

namespace CubicleJockey.StringExtensions.Tests
{
    [TestClass]
    public class ActionsTests
    {
        [TestMethod]
        public void ForEach()
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
    }
}
