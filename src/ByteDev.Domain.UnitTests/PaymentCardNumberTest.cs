using System;
using NUnit.Framework;

namespace ByteDev.Domain.UnitTests
{
    [TestFixture]
    public class PaymentCardNumberTest
    {
        [Test]
        public void WhenNumberIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => new PaymentCardNumber(null));
        }

        [Test]
        public void WhenNummberIsEmpty_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => new PaymentCardNumber(string.Empty));
        }

        [Test]
        public void WhenNumberContainsNonDigits_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => new PaymentCardNumber("548594605X5343963"));
        }

        [Test]
        public void WhenNumberIsValid_ThenSetNumber()
        {
            var sut = new PaymentCardNumber(TestPaymentCardNumbers.ValidMasterCard);

            Assert.That(sut.Number, Is.EqualTo(TestPaymentCardNumbers.ValidMasterCard));
        }

        [Test]
        public void WhenNumberPassesLuhnCheck_ThenSetTrue()
        {
            var sut = new PaymentCardNumber(TestPaymentCardNumbers.ValidMasterCard);

            Assert.That(sut.PassedLuhnCheck, Is.True);
        }

        [Test]
        public void WhenNumberDoesNotPassLuhnCheck_ThenSetFalse()
        {
            var sut = new PaymentCardNumber(TestPaymentCardNumbers.ValidUnknown);

            Assert.That(sut.PassedLuhnCheck, Is.False);
        }

        [TestCase(TestPaymentCardNumbers.ValidUnknown, PaymentCardType.Unknown)]
        [TestCase(TestPaymentCardNumbers.ValidMasterCard, PaymentCardType.MasterCard)]
        [TestCase(TestPaymentCardNumbers.ValidVisa, PaymentCardType.Visa)]
        [TestCase(TestPaymentCardNumbers.ValidVisaElectron, PaymentCardType.VisaElectron)]
        [TestCase(TestPaymentCardNumbers.ValidAmex, PaymentCardType.Amex)]
        [TestCase(TestPaymentCardNumbers.ValidDinersClubCarteBlanche, PaymentCardType.DinersClubCarteBlanche)]
        [TestCase(TestPaymentCardNumbers.ValidDinersClubInternational, PaymentCardType.DinersClubInternational)]
        [TestCase(TestPaymentCardNumbers.ValidDiscover, PaymentCardType.Discover)]
        [TestCase(TestPaymentCardNumbers.ValidInstaPayment, PaymentCardType.InstaPayment)]
        [TestCase(TestPaymentCardNumbers.ValidJcb, PaymentCardType.Jcb)]
        [TestCase(TestPaymentCardNumbers.ValidMaestro, PaymentCardType.Maestro)]
        public void WhenNumberIsValid_ThenSetType(string number, PaymentCardType type)
        {
            var sut = new PaymentCardNumber(number);

            Assert.That(sut.Type, Is.EqualTo(type));
        }
    }
}