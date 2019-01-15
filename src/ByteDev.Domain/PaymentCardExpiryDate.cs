using System;

namespace ByteDev.Domain
{
    public class PaymentCardExpiryDate
    {
        private readonly DateTime _expiryDate;

        /// <summary>
        /// Uses the Month and Year from the DateTime
        /// </summary>
        public PaymentCardExpiryDate(DateTime dateTime)
        {
            _expiryDate = new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// Accepts date in formats: MM/yyyy, MM/yy, MMyyyy, MMyy
        /// </summary>
        public PaymentCardExpiryDate(string monthYear)
        {
            _expiryDate = CreateExpiryDateTimeFrom(monthYear);
        }

        public int Month => _expiryDate.Month;

        public int Year => _expiryDate.Year;

        public string FormattedMmYy => _expiryDate.ToString("MMyy");

        public string FormattedMmYyyy => _expiryDate.ToString("MM/yyyy");

        public bool HasExpired => _expiryDate.AddMonths(1) < DateTime.Now;

        private static DateTime CreateExpiryDateTimeFrom(string monthYear)
        {
            if (monthYear == null)
                throw new ArgumentNullException(nameof(monthYear));

            var expiryDate = monthYear.Replace("/", "");

            if (expiryDate.Length == 4)
            {
                return DateTime.Parse($"01/{expiryDate.Substring(0, 2)}/20{expiryDate.Substring(2, 2)}");
            }
            if (expiryDate.Length == 6)
            {
                return DateTime.Parse($"01/{expiryDate.Substring(0, 2)}/{expiryDate.Substring(2, 4)}");
            }
            throw new ArgumentException("Unexpected expiry date format");
        }
    }
}