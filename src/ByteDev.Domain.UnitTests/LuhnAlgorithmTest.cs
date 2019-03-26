using System;
using NUnit.Framework;

namespace ByteDev.Domain.UnitTests
{
    [TestFixture]
    public class LuhnAlgorithmTest
    {
        private LuhnAlgorithm _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new LuhnAlgorithm();
        }

        [Test]
        public void WhenNumberIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => _sut.Check(null));
        }

        [Test]
        public void WhenNumberIsEmpty_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => _sut.Check(string.Empty));
        }

        [TestCase("79927398713")]
        [TestCase("4539950608270763")]
        [TestCase("5485946055343963")]
        [TestCase("343169701675125")]
        public void WhenNumberIsValid_ThenReturnTrue(string value)
        {
            var result = _sut.Check(value);

            Assert.That(result, Is.True);
        }

        [TestCase("131")]
        [TestCase("123456")]
        [TestCase("1111111111111111")]
        [TestCase("4539950608270764")]
        public void WhenNumberIsInvalid_ThenReturnFalse(string value)
        {
            var result = _sut.Check(value);

            Assert.That(result, Is.False);
        }
    }
}