using System;
using System.Text.RegularExpressions;

namespace ByteDev.Domain
{
    public sealed class EmailAddress : IEquatable<EmailAddress>
    {
        public string Address { get; }

        public string User
        {
            get
            {
                var parts = Address.Split('@');
                return parts[0];
            }
        }

        public string Host
        {
            get
            {
                var parts = Address.Split('@');
                return parts[1];
            }
        }

        public EmailAddress(string address)
        {
            IsValid(address);

            Address = address;
        }

        public bool Equals(EmailAddress other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Address == other.Address;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Equals(other as EmailAddress);
        }

        public override string ToString()
        {
            return Address;
        }

        public override int GetHashCode()
        {
            return Address != null ? Address.GetHashCode() : 0;
        }

        public static void IsValid(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentException("EmailAddress cannot be null or empty", nameof(emailAddress));

            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

            if (!regex.IsMatch(emailAddress))
                throw new ArgumentException($"Email address: '{emailAddress}' is invalid");
        }
    }
}