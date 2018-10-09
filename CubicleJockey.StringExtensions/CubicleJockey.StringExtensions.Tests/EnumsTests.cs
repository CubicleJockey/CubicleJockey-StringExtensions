using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CubicleJockey.StringExtensions.Tests
{
    [TestClass]
    public class EnumsTests
    {
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

        private enum Thingy
        {
            Item1,
            Item2,
            Item3
        }
    }
}
