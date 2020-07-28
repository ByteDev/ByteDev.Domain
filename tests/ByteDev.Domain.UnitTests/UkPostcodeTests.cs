using System;
using NUnit.Framework;

namespace ByteDev.Domain.UnitTests
{
    [TestFixture]
    public class UkPostcodeTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _ = new UkPostcode(null));
            }

            [Test]
            public void WhenHasWhiteSpace_ThenTrimWhiteSpace()
            {
                var sut = new UkPostcode("  A9 9AA      ");

                Assert.That(sut.Value, Is.EqualTo("A99AA"));
            }

            [Test]
            public void WhenIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new UkPostcode(string.Empty));
            }

            [Test]
            public void WhenLengthLessThanFiveChars_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new UkPostcode("A99A"));
            }

            [Test]
            public void WhenLengthMoreThanSevenChars_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new UkPostcode("AA9A9AAA"));
            }

            [Test]
            public void WhenCaseIsLower_ThenSetValueToUpper()
            {
                var sut = new UkPostcode("a99aa");

                Assert.That(sut.Value, Is.EqualTo("A99AA"));
            }

            [TestCase("A9 9AA", "A99AA")]                  // All possible valid formats
            [TestCase("A99 9AA", "A999AA")]
            [TestCase("A9A 9AA", "A9A9AA")]
            [TestCase("AA9 9AA", "AA99AA")]
            [TestCase("AA99 9AA", "AA999AA")]
            [TestCase("AA9A 9AA", "AA9A9AA")]
            public void WhenValidFormat_ThenSetValue(string postCode, string expected)
            {
                var sut = new UkPostcode(postCode);

                Assert.That(sut.Value, Is.EqualTo(expected));
            }

            [TestCase("99999")]
            [TestCase("AA9AA")]
            [TestCase("A9AAA")]
            [TestCase("A999A")]
            [TestCase("A99A9")]
            public void WhenInvalidFiveCharFormat_ThenThrowException(string postCode)
            {
                Assert.Throws<ArgumentException>(() => _ = new UkPostcode(postCode));
            }

            [TestCase("9999AA")]      
            [TestCase("AAA9AA")]      
            [TestCase("A99AAA")]      
            [TestCase("A9999A")]      
            [TestCase("A999A9")]      
            public void WhenInvalidSixCharFormat_ThenThrowException(string postCode)
            {
                Assert.Throws<ArgumentException>(() => _ = new UkPostcode(postCode));
            }

            [TestCase("9A999AA")]      
            [TestCase("A9999AA")]      
            [TestCase("AAA99AA")]      
            [TestCase("AA99AAA")]      
            [TestCase("AA9999A")]      
            [TestCase("AA999A9")]      
            public void WhenInvalidSevenCharFormat_ThenThrowException(string postCode)
            {
                Assert.Throws<ArgumentException>(() => _ = new UkPostcode(postCode));
            }
        }

        [TestFixture]
        public class ValueFormatted
        {
            [Test]
            public void WhenHasNoFormatting_ThenReturnFormatted()
            {
                var sut = new UkPostcode("A99AA");

                Assert.That(sut.ValueFormatted, Is.EqualTo("A9 9AA"));
            } 
        }

        [TestFixture]
        public class OutwardCode
        {
            [TestCase("A9 9AA", "A9")]                  // All possible valid formats
            [TestCase("A99 9AA", "A99")]
            [TestCase("A9A 9AA", "A9A")]
            [TestCase("AA9 9AA", "AA9")]
            [TestCase("AA99 9AA", "AA99")]
            [TestCase("AA9A 9AA", "AA9A")]
            public void WhenValidFormat_ThenSetOutwardCode(string postCode, string expected)
            {
                var sut = new UkPostcode(postCode);

                Assert.That(sut.OutwardCode, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class InwardCode
        {
            [TestCase("A9 9AA", "9AA")]                  // All possible valid formats
            [TestCase("A99 9AA", "9AA")]
            [TestCase("A9A 9AA", "9AA")]
            [TestCase("AA9 9AA", "9AA")]
            [TestCase("AA99 9AA", "9AA")]
            [TestCase("AA9A 9AA", "9AA")]
            public void WhenValidFormat_ThenSetInwardCode(string postCode, string expected)
            {
                var sut = new UkPostcode(postCode);

                Assert.That(sut.InwardCode, Is.EqualTo(expected));
            } 
        }

        [TestFixture]
        public class Area
        {
            [TestCase("A9 9AA", "A")]                  // All possible valid formats
            [TestCase("A99 9AA", "A")]
            [TestCase("A9A 9AA", "A")]
            [TestCase("AA9 9AA", "AA")]
            [TestCase("AA99 9AA", "AA")]
            [TestCase("AA9A 9AA", "AA")]
            public void WhenValidFormat_ThenReturnArea(string postCode, string expected)
            {
                var sut = new UkPostcode(postCode);

                Assert.That(sut.Area, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class District
        {
            [TestCase("A9 9AA", "9")]                  // All possible valid formats
            [TestCase("A99 9AA", "99")]
            [TestCase("A9A 9AA", "9A")]
            [TestCase("AA9 9AA", "9")]
            [TestCase("AA99 9AA", "99")]
            [TestCase("AA9A 9AA", "9A")]
            public void WhenValidFormat_ThenReturnDistrict(string postCode, string expected)
            {
                var sut = new UkPostcode(postCode);

                Assert.That(sut.District, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Sector
        {
            [TestCase("A9 9AA", "9")]                  // All possible valid formats
            [TestCase("A99 9AA", "9")]
            [TestCase("A9A 9AA", "9")]
            [TestCase("AA9 9AA", "9")]
            [TestCase("AA99 9AA", "9")]
            [TestCase("AA9A 9AA", "9")]
            public void WhenValidFormat_ThenReturnSector(string postCode, string expected)
            {
                var sut = new UkPostcode(postCode);

                Assert.That(sut.Sector, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Unit
        {
            [TestCase("A9 9AA", "AA")]                  // All possible valid formats
            [TestCase("A99 9AA", "AA")]
            [TestCase("A9A 9AA", "AA")]
            [TestCase("AA9 9AA", "AA")]
            [TestCase("AA99 9AA", "AA")]
            [TestCase("AA9A 9AA", "AA")]
            public void WhenValidFormat_ThenReturnUnit(string postCode, string expected)
            {
                var sut = new UkPostcode(postCode);

                Assert.That(sut.Unit, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class OverrideToString
        {
            [Test]
            public void WhenCalled_ThenReturnValueFormatted()
            {
                var sut = new UkPostcode("A99AA");

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo(sut.ValueFormatted));
            } 
        }
    }
}