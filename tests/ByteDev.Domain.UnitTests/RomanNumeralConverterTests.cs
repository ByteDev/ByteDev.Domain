using System;
using NUnit.Framework;

namespace ByteDev.Domain.UnitTests
{
    [TestFixture]
    public class RomanNumeralConverterTests
    {
        [TestFixture]
        public class ToRomanNumeral : RomanNumeralConverterTests
        {
            [TestCase(0)]
            [TestCase(-1)]
            public void WhenIsZeroOrMinusNumber_ThenThrowException(int number)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => RomanNumeralConverter.ToRomanNumeral(number));
            }

            [TestCase(1, "I")]
            [TestCase(2, "II")]
            [TestCase(3, "III")]
            [TestCase(4, "IV")]
            [TestCase(5, "V")]
            [TestCase(6, "VI")]
            [TestCase(7, "VII")]
            [TestCase(8, "VIII")]
            [TestCase(9, "IX")]
            [TestCase(10, "X")]
            [TestCase(1910, "MCMX")]
            public void WhenNumberIsPositive_ThenReturnNumeral(int number, string expected)
            {
                var result = RomanNumeralConverter.ToRomanNumeral(number);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToInt32 : RomanNumeralConverterTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenThrowException(string numberal)
            {
                Assert.Throws<ArgumentException>(() => RomanNumeralConverter.ToInt32(numberal));
            }

            [Test]
            public void WhenContainsNonRomanNumeralChar_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => RomanNumeralConverter.ToInt32("MPI"));
            }

            [TestCase("I", 1)]
            [TestCase("II", 2)]
            [TestCase("III", 3)]
            [TestCase("IV", 4)]
            [TestCase("V", 5)]
            [TestCase("VI", 6)]
            [TestCase("VII", 7)]
            [TestCase("VIII", 8)]
            [TestCase("IX", 9)]
            [TestCase("X", 10)]
            [TestCase("M", 1000)]
            [TestCase("MI", 1001)]
            [TestCase("MIV", 1004)]
            [TestCase("MCMX", 1910)]
            public void WhenValid_ThenReturnInt(string numeral, int expected)
            {
                var result = RomanNumeralConverter.ToInt32(numeral);

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}