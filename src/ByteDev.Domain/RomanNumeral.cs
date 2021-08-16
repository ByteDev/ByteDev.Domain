namespace ByteDev.Domain
{
    internal class RomanNumeral
    {
        public int Number { get; }

        public string Numeral { get; }

        public RomanNumeral(int number, string romanNumeral)
        {
            Number = number;
            Numeral = romanNumeral;
        }
    }
}