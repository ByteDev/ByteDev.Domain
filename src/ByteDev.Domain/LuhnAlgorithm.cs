using System;
using System.Linq;

namespace ByteDev.Domain
{
    public class LuhnAlgorithm
    {
        public bool Execute(string number)
        {
            if(string.IsNullOrEmpty(number))
                throw new ArgumentException("Number was empty or null.", nameof(number));

            var total = 0;
            var isEven = false;

            for (var i = number.Length - 1; i >= 0; i--)
            {
                int value = Convert.ToInt32(number[i].ToString());

                if (isEven)
                    value = value * 2;

                if (value > 9)
                    value = AddDigits(value);

                total += value;

                isEven = !isEven;
            }

            return total % 10 == 0;
        }

        private static int AddDigits(int value)
        {
            return value.ToString()
                .Sum(digit => Convert.ToInt32(digit.ToString()));
        }
    }
}