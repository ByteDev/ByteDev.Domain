using System;
using System.Linq;

namespace ByteDev.Domain
{
    public class PaymentCardNumber
    {
        private static readonly int[] _maestroPrefixes = { 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763 };

        public string Number;

        public PaymentCardType Type { get; }

        public bool PassedLuhnCheck { get; }

        public PaymentCardNumber(string number)
        {
            if(string.IsNullOrEmpty(number))
                throw new ArgumentException("Number was empty or null.", nameof(number));

            if(!number.ContainsOnlyDigits())
                throw new ArgumentException("Number contains non-numeric characters.", nameof(number));

            Number = number;
            Type = GetCreditCardType(number);
            PassedLuhnCheck = new LuhnAlgorithm().Check(number);
        }

        private static PaymentCardType GetCreditCardType(string number)
        {
            if (CheckIsVisaElectron(number))
                return PaymentCardType.VisaElectron;
            
            if (CheckIsDiscover(number))
                return PaymentCardType.Discover;

            if (CheckIsInstaPayment(number))
                return PaymentCardType.InstaPayment;

            if (CheckIsJcb(number))
                return PaymentCardType.Jcb;

            if (CheckIsMaestro(number))
                return PaymentCardType.Maestro;

            if (CheckIsAmex(number))
                return PaymentCardType.Amex;

            if (CheckIsMasterCard(number))
                return PaymentCardType.MasterCard;

            if (CheckIsDinersClubCarteBlanche(number))
                return PaymentCardType.DinersClubCarteBlanche;

            if (CheckIsDinersClubInternational(number))
                return PaymentCardType.DinersClubInternational;

            if (CheckIsMasterCard(number))
                return PaymentCardType.MasterCard;

            if (CheckIsVisa(number))
                return PaymentCardType.Visa;

            return PaymentCardType.Unknown;
        }
        
        private static bool CheckIsMaestro(string number)
        {
            int firstFour = number.FirstDigits(4);

            return _maestroPrefixes.Contains(firstFour) &&
                   number.IsLengthBetween(16, 19);
        }

        private static bool CheckIsJcb(string number)
        {
            int firstFour = number.FirstDigits(4);

            return firstFour >= 3528 && firstFour <= 3589 &&
                   number.IsLengthBetween(16, 19);
        }

        private static bool CheckIsInstaPayment(string number)
        {
            int firstThree = number.FirstDigits(3);

            return firstThree >= 637 && firstThree <= 639 &&
                   number.Length == 16;
        }

        private static bool CheckIsDiscover(string number)
        {
            int firstSix = number.FirstDigits(6);
            int firstThree = number.FirstDigits(3);

            return (firstSix >= 622126 && firstSix <= 622925) ||
                   number.FirstDigits(4) == 6011 ||
                   (firstThree >= 644 && firstThree <= 649) ||
                   number.FirstDigits(2) == 65 &&
                   number.IsLengthBetween(16, 19);
        }

        private static bool CheckIsMasterCard(string number)
        {
            // Joint venture between DinersClub and MasterCard start with 5 and have len 16 (should treat as MasterCard)

            int firstTwoDigits = number.FirstDigits(2);
            int firstFoutDigits = number.FirstDigits(4);

            return firstTwoDigits >= 51 && firstTwoDigits <= 55 ||
                   firstFoutDigits >= 2221 && firstFoutDigits <= 2720 &&
                   number.Length == 16;
        }

        private static bool CheckIsDinersClubInternational(string number)
        {
            var firstTwo = number.FirstDigits(2);

            return firstTwo == 36 || firstTwo == 38 && 
                   number.Length == 14;
        }

        private static bool CheckIsDinersClubCarteBlanche(string number)
        {
            int firstThree = number.FirstDigits(3);

            return firstThree >= 300 && firstThree <= 305 &&
                   number.Length == 14;
        }

        private static bool CheckIsVisaElectron(string number)
        {
            var firstFour = number.FirstDigits(4);

            return firstFour == 4026 || firstFour == 4508 || firstFour == 4844 || firstFour == 4913 || firstFour == 4917 ||
                   number.FirstDigits(6) == 417500 &&
                   number.Length == 16;
        }

        private static bool CheckIsAmex(string number)
        {
            int firstTwoDigits = number.FirstDigits(2);

            return firstTwoDigits == 34 || firstTwoDigits == 37 && number.Length == 15;
        }

        private static bool CheckIsVisa(string number)
        {
            return number.FirstDigits(1) == 4 && 
                   (number.Length == 13 || number.Length == 16 || number.Length == 18 || number.Length == 19);
        }
    }
}