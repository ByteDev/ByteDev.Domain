using NUnit.Framework;

namespace ByteDev.Domain.UnitTests
{
    [TestFixture]
    public class TemperatureConvertTests
    {
        [TestFixture]
        public class CelsiusToFahrenheit : TemperatureConvertTests
        {
            [TestCase(-1, 30.2d)]
            [TestCase(0, 32d)]
            [TestCase(1, 33.8d)]
            [TestCase(10, 50d)]
            [TestCase(100, 212d)]
            public void WhenCelsiusSupplied_ThenReturnFahrenheit(double celsius, double expected)
            {
                var result = TemperatureConvert.CelsiusToFahrenheit(celsius);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class CelsiusToKelvin : TemperatureConvertTests
        {
            [TestCase(-1, 272.15d)]
            [TestCase(0, 273.15d)]
            [TestCase(1, 274.15d)]
            [TestCase(10, 283.15d)]
            [TestCase(100, 373.15d)]
            public void WhenCelsiusSupplied_ThenReturnKelvin(double celsius, double expected)
            {
                var result = TemperatureConvert.CelsiusToKelvin(celsius);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class FahrenheitToCelsius : TemperatureConvertTests
        {
            [TestCase(-1, -18.333333333333332d)]
            [TestCase(0, -17.777777777777778d)]
            [TestCase(1, -17.2222222222222223d)]
            [TestCase(10, -12.222222222222221d)]
            [TestCase(100, 37.777777777777778d)]
            public void WhenFahrenheitSupplied_ThenReturnCelsius(double fahrenheit, double expected)
            {
                var result = TemperatureConvert.FahrenheitToCelsius(fahrenheit);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class FahrenheitToKelvin : TemperatureConvertTests
        {
            [TestCase(-1, 254.81666666666663d)]
            [TestCase(0, 255.37222222222221d)]
            [TestCase(1, 255.92777777777775d)]
            [TestCase(10, 260.92777777777775d)]
            [TestCase(100, 310.92777777777775d)]
            public void WhenFahrenheitSupplied_ThenReturnKelvin(double fahrenheit, double expected)
            {
                var result = TemperatureConvert.FahrenheitToKelvin(fahrenheit);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class KelvinToCelsius : TemperatureConvertTests
        {
            [TestCase(-1, -274.15d)]
            [TestCase(0, -273.15d)]
            [TestCase(1, -272.15d)]
            [TestCase(10, -263.15d)]
            [TestCase(100, -173.14999999999998d)]
            public void WhenKelvinSupplied_ThenReturnCelsius(double kelvin, double expected)
            {
                var result = TemperatureConvert.KelvinToCelsius(kelvin);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class KelvinToFahrenheit : TemperatureConvertTests
        {
            [TestCase(-1, -461.46999999999997d)]
            [TestCase(0, -459.66999999999996d)]
            [TestCase(1, -457.87d)]
            [TestCase(10, -441.66999999999996d)]
            [TestCase(100, -279.66999999999996d)]
            public void WhenKelvinSupplied_ThenReturnFahrenheit(double kelvin, double expected)
            {
                var result = TemperatureConvert.KelvinToFahrenheit(kelvin);

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}