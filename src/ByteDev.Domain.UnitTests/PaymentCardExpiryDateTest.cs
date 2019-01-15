using System;
using NUnit.Framework;

namespace ByteDev.Domain.UnitTests
{
    [TestFixture]
    public class PaymentCardExpiryDateTest
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void WhenDateTimeSupplied_ShouldSetDateTime()
            {
                var expiryDate = new DateTime(2015, 1, 5);

                var sut = new PaymentCardExpiryDate(expiryDate);

                Assert.That(sut.Month, Is.EqualTo(1));
                Assert.That(sut.Year, Is.EqualTo(2015));
            }

            [Test]
            public void WhenDateStringIsNull_ShouldThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => new PaymentCardExpiryDate(null));
            }

            [Test]
            public void WhenDateStringIsEmpty_ShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() => new PaymentCardExpiryDate(string.Empty));
            }

            [Test]
            public void WhenDateInMmYyStringFormat_ShouldSetDateTime()
            {
                var expiryDate = new DateTime(2015, 1, 5).ToString("MMyy");

                var sut = new PaymentCardExpiryDate(expiryDate);

                Assert.That(sut.Month, Is.EqualTo(1));
                Assert.That(sut.Year, Is.EqualTo(2015));
            }

            [Test]
            public void WhenDateInMmYyyyStringFormat_ShouldSetDateTime()
            {
                var expiryDate = new DateTime(2015, 1, 5).ToString("MMyyyy");

                var sut = new PaymentCardExpiryDate(expiryDate);

                Assert.That(sut.Month, Is.EqualTo(1));
                Assert.That(sut.Year, Is.EqualTo(2015));
            }

            [Test]
            public void WhenDateInMmYyWithSlashInStringFormat_ShouldSetDateTime()
            {
                var expiryDate = new DateTime(2015, 1, 5).ToString("MM/yy");

                var sut = new PaymentCardExpiryDate(expiryDate);

                Assert.That(sut.Month, Is.EqualTo(1));
                Assert.That(sut.Year, Is.EqualTo(2015));
            }

            [Test]
            public void WhenDateIsInvalidStringFormat_ShouldThrowException()
            {
                var expiryDate = new DateTime(2015, 1, 5).ToString("dd/MM/yyyy");

                Assert.Throws<ArgumentException>(() => new PaymentCardExpiryDate(expiryDate));
            }
        }

        [TestFixture]
        public class FormattedMmYy
        {
            [Test]
            public void WhenDateTimeSet_ShouldReturnInMmYyFormat()
            {
                var expiryDate = new DateTime(2015, 1, 5);
                var sut = new PaymentCardExpiryDate(expiryDate);

                var result = sut.FormattedMmYy;

                Assert.That(result, Is.EqualTo("0115"));
            }
        }

        [TestFixture]
        public class FormattedMmYyyy
        {
            [Test]
            public void WhenDateTimeSet_ShouldReturnInMmYyyyFormat()
            {
                var expiryDate = new DateTime(2015, 1, 5);
                var sut = new PaymentCardExpiryDate(expiryDate);

                var result = sut.FormattedMmYyyy;

                Assert.That(result, Is.EqualTo("01/2015"));
            }
        }

        [TestFixture]
        public class HasExpired
        {
            [Test]
            public void WhenExpiryDateIsNextMonth_ShouldReturnFalse()
            {
                var expiryDate = DateTime.Now.AddMonths(1);
                var sut = new PaymentCardExpiryDate(expiryDate);

                var result = sut.HasExpired;

                Assert.IsFalse(result);
            }

            [Test]
            public void WhenExpiryDateIsThisMonth_ShouldReturnFalse()
            {
                var expiryDate = DateTime.Now;
                var sut = new PaymentCardExpiryDate(expiryDate);

                var result = sut.HasExpired;

                Assert.IsFalse(result);
            }

            [Test]
            public void WhenExpiryDateIsLastMonth_ShouldReturnTrue()
            {
                var expiryDate = DateTime.Now.AddMonths(-1);
                var sut = new PaymentCardExpiryDate(expiryDate);

                var result = sut.HasExpired;

                Assert.IsTrue(result);
            }
        }
    }
}