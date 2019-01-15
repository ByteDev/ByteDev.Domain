using System;
using System.Text.RegularExpressions;

namespace ByteDev.Domain
{
    /// <summary>
    /// Represents a UK postcode.
    /// Components:
    /// Postcode = [OutwardCode + InwardCode]
    /// OutwardCode = [Area + District]
    /// InwardCode = [Sector + Unit]
    /// 
    /// Example:
    /// PO1 3AX: PO = Area, 1 = District, 3 = Sector, AX = Unit
    /// 
    /// Further information: 
    /// https://www.mrs.org.uk/pdf/postcodeformat.pdf
    /// http://en.wikipedia.org/wiki/Postcodes_in_the_United_Kingdom
    /// </summary>
    public class UkPostcode
    {
        private const string SectorRegEx = @"\d";
        private const string UnitRegEx = @"[A-Z][A-Z]";

        private static readonly char[] Digits = "0123456789".ToCharArray();

        public UkPostcode(string postCode)
        {
            if (postCode == null)
                throw new ArgumentNullException(nameof(postCode));

            var tempPostCode = postCode.RemoveWhiteSpace().ToUpper();

            Validate(tempPostCode);
            Value = tempPostCode;
        }

        /// <summary>
        /// Returns Postcode string without any formatting.
        /// Example: "A99AA"
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Returns Postcode string formatted with a space
        /// between the OutwardCode and InwardCode.
        /// Example: "A9 9AA"
        /// </summary>
        public string ValueFormatted => Value.Insert(GetIndexOfLastDigit(Value), " ");

        /// <summary>
        /// Returns the OutwardCode of the Postcode
        /// (the first part of the Postcode).
        /// </summary>
        public string OutwardCode => Value.Substring(0, GetIndexOfLastDigit(Value));

        /// <summary>
        /// Returns the Area part of the Postcode
        /// (the first alpha chars (from the OutwardCode)).
        /// </summary>
        public string Area => OutwardCode.Substring(0, GetIndexOfFirstDigit(OutwardCode));

        /// <summary>
        /// Returns the District part of the Postcode
        /// (the remaining numeric and alpha chars after the Area from the OutwardCode).
        /// </summary>
        public string District => OutwardCode.Substring(Area.Length);

        /// <summary>
        /// Returns the InwardCode part of the Postcode
        /// (the second part of the Postcode).
        /// </summary>
        public string InwardCode => Value.Substring(GetIndexOfLastDigit(Value));

        /// <summary>
        /// Returns the Sector of the Postcode
        /// (the first digit of the InwardCode)
        /// </summary>
        public string Sector => InwardCode.Substring(0, 1);

        /// <summary>
        /// Returns the Unit of the Postcode
        /// (the remainder of the InwardCode after the Sector)
        /// </summary>
        public string Unit => InwardCode.Substring(GetIndexOfFirstDigit(InwardCode) + 1);

        public override string ToString()
        {
            return ValueFormatted;
        }

        private static void Validate(string postCode)
        {
            const string inwardCodeRegEx = @SectorRegEx + UnitRegEx + "$";

            switch (postCode.Length)
            {
                case 5:
                    // Valid: A99AA
                    ValidateFormat(postCode, @"^[A-Z]\d" + inwardCodeRegEx);
                    break;
                case 6:
                    // Valid: A9A9AA, A999AA, AA99AA
                    ValidateFormat(postCode, @"^[A-Z]((\d[A-Z])|(\d\d)|([A-Z]\d))" + inwardCodeRegEx);
                    break;
                case 7:
                    // Valid: AA999AA, AA9A9AA
                    ValidateFormat(postCode, @"^[A-Z][A-Z]\d(\d|[A-Z])" + inwardCodeRegEx);
                    break;
                default:
                    throw new ArgumentException("Postcode must be between 5 and 7 alpha numeric chars long");
            }
        }

        private static void ValidateFormat(string postCode, string regEx)
        {
            var regex = new Regex(regEx);

            if (!regex.IsMatch(postCode))
                throw new ArgumentException("Postcode is in invalid format");
        }

        private static int GetIndexOfFirstDigit(string text)
        {
            var firstDigit = text.IndexOfAny(Digits);
            if (firstDigit == -1)
            {
                throw new InvalidOperationException("Postcode does not contain any digits");
            }
            return firstDigit;
        }

        private static int GetIndexOfLastDigit(string text)
        {
            var lastDigit = text.LastIndexOfAny(Digits);

            if (lastDigit == -1)
            {
                throw new InvalidOperationException("Postcode does not contain any digits");
            }
            return lastDigit;
        }
    }
}