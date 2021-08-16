using System;
using System.Text;

namespace ByteDev.Domain
{
    public static class RomanNumeralConverter
    {
        private static readonly RomanNumeral[] RomanNumerals =
        {
            new RomanNumeral(1000, "M"),
            new RomanNumeral(900, "CM"),
            new RomanNumeral(500, "D"),
            new RomanNumeral(400, "CD"),
            new RomanNumeral(100, "C"),
            new RomanNumeral(90, "XC"),
            new RomanNumeral(50, "L"),
            new RomanNumeral(40, "XL"),
            new RomanNumeral(10, "X"),
            new RomanNumeral(9, "IX"),
            new RomanNumeral(5, "V"),
            new RomanNumeral(4, "IV"),
            new RomanNumeral(1, "I")
        };
        
        public static string ToRomanNumeral(int number)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException(nameof(number), "Value must be one or more. There are no Roman numeral representations of zero or minus numbers.");

            var sb = new StringBuilder();

            foreach (var currentRN in RomanNumerals)
            {
                while (number >= currentRN.Number)
                {
                    number -= currentRN.Number;
                    sb.Append(currentRN.Numeral);
                }

                if (number == 0)
                    break;
            }

            return sb.ToString();
        }

        public static int ToInt32(string romanNumeral)
        {
            if (string.IsNullOrEmpty(romanNumeral))
                throw new ArgumentException("Roman numeral is null or empty");

            int total = 0;

            for (var i = 0; i < romanNumeral.Length; i++)
            {
                var ch = romanNumeral[i];
                int chNumber = ch.GetRomanNumeralAsInt();

                var nextCh = romanNumeral.SafeGetChar(i + 1);

                if (nextCh == '\0')
                {
                    total += chNumber;
                }
                else
                {
                    int nextChNumber = nextCh.GetRomanNumeralAsInt();

                    if (nextChNumber > chNumber)
                    {
                        total += nextChNumber - chNumber;
                        i++;
                    }
                    else
                    {
                        total += chNumber;
                    }
                }
            }

            return total;
        }
    }
}