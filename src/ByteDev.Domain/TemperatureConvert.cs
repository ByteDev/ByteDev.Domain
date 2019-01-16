namespace ByteDev.Domain
{
    public class TemperatureConvert
    {
        public static  double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        public static double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15d;
        }

        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public static double FahrenheitToKelvin(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9 + 273.15d;
        }

        public static double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15d;
        }

        public static double KelvinToFahrenheit(double kelvin)
        {
            return (kelvin - 273.15d) * 9 / 5 + 32;
        }
    }
}