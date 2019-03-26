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

        [TestCase(TestPaymentCardNumbers.ValidUnknown, CreditCardType.Unknown)]
        [TestCase(TestPaymentCardNumbers.ValidMasterCard, CreditCardType.MasterCard)]
        [TestCase(TestPaymentCardNumbers.ValidVisa, CreditCardType.Visa)]
        [TestCase(TestPaymentCardNumbers.ValidVisaElectron, CreditCardType.VisaElectron)]
        [TestCase(TestPaymentCardNumbers.ValidAmex, CreditCardType.Amex)]
        [TestCase(TestPaymentCardNumbers.ValidDinersClubCarteBlanche, CreditCardType.DinersClubCarteBlanche)]
        [TestCase(TestPaymentCardNumbers.ValidDinersClubInternational, CreditCardType.DinersClubInternational)]
        [TestCase(TestPaymentCardNumbers.ValidDiscover, CreditCardType.Discover)]
        [TestCase(TestPaymentCardNumbers.ValidInstaPayment, CreditCardType.InstaPayment)]
        [TestCase(TestPaymentCardNumbers.ValidJcb, CreditCardType.Jcb)]
        [TestCase(TestPaymentCardNumbers.ValidMaestro, CreditCardType.Maestro)]
        public void WhenNumberIsValid_ThenSetType(string number, CreditCardType type)
        {
            var sut = new PaymentCardNumber(number);

            Assert.That(sut.Type, Is.EqualTo(type));
        }
    }
}