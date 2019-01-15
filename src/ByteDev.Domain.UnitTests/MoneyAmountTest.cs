using NUnit.Framework;

namespace ByteDev.Domain.UnitTests
{
    [TestFixture]
    public class MoneyAmountTest
    {
        [TestFixture]
        public class Pennies
        {
            [Test]
            public void WhenPenniesSet_ShouldReturnPennies()
            {
                const int pennies = 10;

                var sut = new MoneyAmount(pennies);

                Assert.That(sut.Pennies, Is.EqualTo(pennies));
            }
        }

        [TestFixture]
        public class PoundsAndPennies
        {
            [Test]
            public void WhenZeroPennies_ShouldReturnZero()
            {
                var sut = new MoneyAmount(0);

                var result = sut.PoundsAndPennies;

                Assert.AreEqual(0, result);
            }

            [Test]
            public void WhenOneHundredAndElevenPennies_ShouldReturnOnePoundElevenPennies()
            {
                var sut = new MoneyAmount(111);

                var result = sut.PoundsAndPennies;

                Assert.AreEqual(1.11M, result);
            }

            [Test]
            public void WhenMaxPennies_ShouldReturnAsPoundsAndPence()
            {
                var sut = new MoneyAmount(2147483647);

                var result = sut.PoundsAndPennies;

                Assert.AreEqual(21474836.47M, result);
            }

            [Test]
            public void WhenNegativePennies_ShouldReturnNegativePoundsAndPence()
            {
                var sut = new MoneyAmount(-12345);

                var result = sut.PoundsAndPennies;

                Assert.AreEqual(-123.45M, result);
            }
        }

        [TestFixture]
        public class FormattedPoundsAndPence
        {
            [Test]
            public void WhenZeroPennies_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(0);

                var result = sut.FormattedPoundsAndPence;

                Assert.That(result, Is.EqualTo("£0.00"));
            }

            [Test]
            public void WhenOneDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(8);

                var result = sut.FormattedPoundsAndPence;

                Assert.That(result, Is.EqualTo("£0.08"));
            }

            [Test]
            public void WhenTwoDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(85);

                var result = sut.FormattedPoundsAndPence;

                Assert.That(result, Is.EqualTo("£0.85"));
            }

            [Test]
            public void WhenThreeDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(852);

                var result = sut.FormattedPoundsAndPence;

                Assert.That(result, Is.EqualTo("£8.52"));
            }

            [Test]
            public void WhenOneThousandPounds_ShouldAddCommaToFormattedString()
            {
                var sut = new MoneyAmount(100000);

                var result = sut.FormattedPoundsAndPence;

                Assert.That(result, Is.EqualTo("£1,000.00"));
            }

            [Test]
            public void WhenPenniesIsMaxInt_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(2147483647);

                var result = sut.FormattedPoundsAndPence;

                Assert.That(result, Is.EqualTo("£21,474,836.47"));
            }

            [Test]
            public void WhenNegativePenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(-852);

                var result = sut.FormattedPoundsAndPence;

                Assert.That(result, Is.EqualTo("-£8.52"));
            }
        }

        [TestFixture]
        public class FormattedPoundsAndPenceNoSign
        {
            [Test]
            public void WhenZeroPennies_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(0);

                var result = sut.FormattedPoundsAndPenceNoSign;

                Assert.AreEqual("£0.00", result);
            }

            [Test]
            public void WhenOneDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(8);

                var result = sut.FormattedPoundsAndPenceNoSign;

                Assert.AreEqual("£0.08", result);
            }

            [Test]
            public void WhenTwoDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(85);

                var result = sut.FormattedPoundsAndPenceNoSign;

                Assert.AreEqual("£0.85", result);
            }

            [Test]
            public void WhenThreeDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(852);

                var result = sut.FormattedPoundsAndPenceNoSign;

                Assert.AreEqual("£8.52", result);
            }

            [Test]
            public void WhenOneThousandPounds_ShouldAddCommaToFormattedString()
            {
                var sut = new MoneyAmount(100000);

                var result = sut.FormattedPoundsAndPenceNoSign;

                Assert.AreEqual("£1,000.00", result);
            }

            [Test]
            public void WhenPenniesIsMaxInt_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(2147483647);

                var result = sut.FormattedPoundsAndPenceNoSign;

                Assert.AreEqual("£21,474,836.47", result);
            }

            [Test]
            public void WhenNegativePenniesSet_ShouldReturnFormattedPoundsAndPenceWithoutSign()
            {
                var sut = new MoneyAmount(-852);

                var result = sut.FormattedPoundsAndPenceNoSign;

                Assert.AreEqual("£8.52", result);
            }
        }

        [TestFixture]
        public class FormattedPoundsAndPenceNoComma
        {
            [Test]
            public void WhenZeroPennies_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(0);

                var result = sut.FormattedPoundsAndPenceNoComma;

                Assert.That(result, Is.EqualTo("£0.00"));
            }

            [Test]
            public void WhenOneDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(8);

                var result = sut.FormattedPoundsAndPenceNoComma;

                Assert.That(result, Is.EqualTo("£0.08"));
            }

            [Test]
            public void WhenTwoDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(85);

                var result = sut.FormattedPoundsAndPenceNoComma;

                Assert.That(result, Is.EqualTo("£0.85"));
            }

            [Test]
            public void WhenThreeDigitPenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(852);

                var result = sut.FormattedPoundsAndPenceNoComma;

                Assert.That(result, Is.EqualTo("£8.52"));
            }

            [Test]
            public void WhenOneThousandPounds_ShouldReturnFormattedWithNoComma()
            {
                var sut = new MoneyAmount(100000);

                var result = sut.FormattedPoundsAndPenceNoComma;

                Assert.That(result, Is.EqualTo("£1000.00"));
            }

            [Test]
            public void WhenNegativePenniesSet_ShouldReturnFormattedPoundsAndPence()
            {
                var sut = new MoneyAmount(-852);

                var result = sut.FormattedPoundsAndPenceNoComma;

                Assert.That(result, Is.EqualTo("-£8.52"));
            }
        }
    }
}