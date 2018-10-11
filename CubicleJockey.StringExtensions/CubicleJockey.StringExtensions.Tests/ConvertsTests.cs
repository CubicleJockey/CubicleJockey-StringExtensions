using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CubicleJockey.StringExtensions.Tests
{
    [TestClass]
    public class ConvertsTests
    {

        #region Enums

        [TestMethod]
        public void TypeWasNotEnum()
        {
            Action method = () => "SomeString".ToEnum<int>();

            method.Should()
                  .Throw<ArgumentException>()
                  .WithMessage("Type TEnum must be of type System.Enum");
        }

        [TestMethod]
        public void ValidEnumsFoundNoCaseIgnored()
        {
            "Item1".ToEnum<Thingy>().Should().Be(Thingy.Item1);
            "Item2".ToEnum<Thingy>().Should().Be(Thingy.Item2);
            "Item3".ToEnum<Thingy>().Should().Be(Thingy.Item3);
        }

        [TestMethod]
        public void ValidEnumsFoundCaseIgnored()
        {
            "item1".ToEnum<Thingy>(true).Should().Be(Thingy.Item1);
            "item2".ToEnum<Thingy>(true).Should().Be(Thingy.Item2);
            "item3".ToEnum<Thingy>(true).Should().Be(Thingy.Item3);
        }

        [TestMethod]
        public void NoValidEnumsFoundDueToCase()
        {
            "item1".ToEnum<Thingy>().Should().BeNull();
            "item2".ToEnum<Thingy>().Should().BeNull();
            "item3".ToEnum<Thingy>().Should().BeNull();
        }

        [TestMethod]
        public void NotInEnum()
        {
            var result = "IamNotInThingyEnum".ToEnum<Thingy>();

            result.HasValue.Should().BeFalse();
        }

        #endregion Enums

        #region Boolean

        [TestMethod]
        public void ToBoolean_True()
        {
            bool.TrueString.ToBoolean().Should().BeTrue();
        }

        [TestMethod]
        public void ToBoolean_true()
        {
            bool.TrueString.ToLower().ToBoolean().Should().BeTrue();
        }

        [TestMethod]
        public void ToBoolean_False()
        {
            bool.FalseString.ToBoolean().Should().BeFalse();
        }

        [TestMethod]
        public void ToBoolean_false()
        {
            bool.FalseString.ToLower().ToBoolean().Should().BeFalse();
        }

        [TestMethod]
        public void ToBoolean_Yes()
        {
            "Yes".ToBoolean().Should().BeTrue();
        }

        [TestMethod]
        public void ToBoolean_yes()
        {
            "yes".ToBoolean().Should().BeTrue();
        }

        [TestMethod]
        public void ToBoolean_Y()
        {
            "Y".ToBoolean().Should().BeTrue();
        }

        [TestMethod]
        public void ToBoolean_y()
        {
            "y".ToBoolean().Should().BeTrue();
        }

        [TestMethod]
        public void ToBoolean_No()
        {
            "No".ToBoolean().Should().BeFalse();
        }

        [TestMethod]
        public void ToBoolean_no()
        {
            "no".ToBoolean().Should().BeFalse();
        }

        [TestMethod]
        public void ToBoolean_N()
        {
            "N".ToBoolean().Should().BeFalse();
        }

        [TestMethod]
        public void ToBoolean_n()
        {
            "n".ToBoolean().Should().BeFalse();
        }

        [TestMethod]
        public void ToBoolean_1()
        {
            "1".ToBoolean().Should().BeTrue();
        }

        [TestMethod]
        public void ToBoolean_0()
        {
            "0".ToBoolean().Should().BeFalse();
        }

        [DataRow(default(string))]
        [DataRow("")]
        [DataRow("     ")]
        [DataTestMethod]
        public void ToBoolean_Empty(string value)
        {
            Action method = () => value.ToBoolean();

            method.Should()
                  .Throw<ArgumentException>()
                  .WithMessage("Invalid Boolean: Accepted Values: [True, true, False, false, Yes, yes, No, no, Y, y, N, n, 1, 0]");
        }

        [DataRow("Not a boolean")]
        [DataRow("Nope")]
        [DataRow("Fart")]
        [DataTestMethod]
        public void ToBoolean_InvalidValues(string value)
        {
            Action method = () => value.ToBoolean();

            method.Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid Boolean: Accepted Values: [True, true, False, false, Yes, yes, No, no, Y, y, N, n, 1, 0]");
        }

        #endregion Boolean

        #region Helpers

        private enum Thingy
        {
            Item1,
            Item2,
            Item3
        }

        #endregion Helpers
    }
}
