using System;

namespace ByteDev.Domain
{
    public class MoneyAmount
    {
        public MoneyAmount(int pennies)
        {
            Pennies = pennies;
        }

        public int Pennies { get; }

        public decimal PoundsAndPennies => Convert.ToDecimal(Pennies) / 100;

        public string FormattedPoundsAndPence => $"{PoundsAndPennies:C}";

        public string FormattedPoundsAndPenceNoSign => $"{Math.Abs(PoundsAndPennies):C}";

        public string FormattedPoundsAndPenceNoComma => $"{PoundsAndPennies:£0.00}";
    }
}