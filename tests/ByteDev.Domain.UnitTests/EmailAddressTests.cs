using System;
using NUnit.Framework;

namespace ByteDev.Domain.UnitTests
{
    [TestFixture]
    public class EmailAddressTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void WhenAddressIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new EmailAddress(null));
            }

            [Test]
            public void WhenAddressIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new EmailAddress(string.Empty));
            }

            [Test]
            public void WhenAddressHasNoAt_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new EmailAddress("someone"));
            }

            [Test]
            public void WhenAddressHasNoUser_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new EmailAddress("@somewhere.com"));
            }

            [Test]
            public void WhenAddressHasNoHost_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new EmailAddress("someone@"));
            }

            [Test]
            public void WhenAddressHasNoHostTld_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new EmailAddress("a@somewhere"));
            }

            [Test]
            public void WhenAddressHasMoreThanOneAt_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new EmailAddress("someone@@somewhere.com"));
            }

            [Test]
            public void WhenAddressIsValid_ThenSetAddress()
            {
                const string validAddress = "someone@somewhere.com";

                var sut = new EmailAddress(validAddress);

                Assert.That(sut.Address, Is.EqualTo(validAddress));
            }

            [Test]
            public void WhenAddressIsShort_ThenSetAddress()
            {
                const string validAddress = "a@a.a";

                var sut = new EmailAddress(validAddress);

                Assert.That(sut.Address, Is.EqualTo(validAddress));
            }

            [Test]
            public void WhenAddressTldIsVeryLong_ThenSetAddress()
            {
                const string validAddress = "a@a.aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

                var sut = new EmailAddress(validAddress);

                Assert.That(sut.Address, Is.EqualTo(validAddress));
            }
        }

        [TestFixture]
        public class User
        {
            [Test]
            public void WhenAddressIsValid_ThenReturnUser()
            {
                const string validAddress = "someone@somewhere.com";

                var sut = new EmailAddress(validAddress);

                Assert.That(sut.User, Is.EqualTo("someone"));
            }

            [Test]
            public void WhenUserIsOneChar_ThenReturnUser()
            {
                const string validAddress = "a@somewhere.com";

                var sut = new EmailAddress(validAddress);

                Assert.That(sut.User, Is.EqualTo("a"));
            }
        }

        [TestFixture]
        public class Host
        {
            [Test]
            public void WhenAddressIsValid_ThenReturnHost()
            {
                const string validAddress = "someone@somewhere.com";

                var sut = new EmailAddress(validAddress);

                Assert.That(sut.Host, Is.EqualTo("somewhere.com"));
            }

            [Test]
            public void WhenHostIsThreeChar_ThenReturnHost()
            {
                const string validAddress = "someone@a.a";

                var sut = new EmailAddress(validAddress);

                Assert.That(sut.Host, Is.EqualTo("a.a"));
            }
        }

        [TestFixture]
        public class OverrideToString
        {
            [Test]
            public void WhenCalled_ThenReturnAddress()
            {
                var sut = new EmailAddress("someone@somewhere.com");

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo(sut.Address));
            }
        }

        [TestFixture]
        public class OverrideEquals
        {
            [Test]
            public void WhenIsNull_ThenReturnFalse()
            {
                var sut = new EmailAddress("someone@somewhere.com");

                var result = sut.Equals(null);

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenIsNotEmailAddress_ThenReturnFalse()
            {
                var sut = new EmailAddress("someone@somewhere.com");

                var result = sut.Equals(new object());

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenDifferentObjsHaveEqualAddress_ThenReturnTrue()
            {
                var otherEmail = new EmailAddress("someone@somewhere.com");

                var sut = new EmailAddress(otherEmail.Address);

                var result = sut.Equals(otherEmail);

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenDifferentObjsHasNotEqualAddress_ThenReturnFalse()
            {
                var otherEmail = new EmailAddress("someone@somewhere.com");

                var sut = new EmailAddress("someone2@somewhere.com");

                var result = sut.Equals(otherEmail);

                Assert.That(result, Is.False);
            }
        }
    }
}