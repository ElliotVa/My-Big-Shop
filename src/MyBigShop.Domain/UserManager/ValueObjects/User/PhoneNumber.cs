using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyBigShop.Domain.UserManager.ValueObjects.User
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; }
        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "Phone number cannot be empty");
            var nationalCode = value[..2]; // Get the third character of the phone number
            if (string.IsNullOrWhiteSpace(nationalCode))
                throw new ArgumentException("Phone number must include a valid national code", nameof(value));
            if (nationalCode != "09")
                throw new ArgumentException("Phone number must start with '09'", nameof(value));
            if (value.Length is < 10 or > 11)
                throw new ArgumentException("Phone number must be between 10 and 11 characters", nameof(value));
            if (!Regex.IsMatch(value, @"^09\d{9}$"))
                throw new ArgumentException("Phone number must be a valid Iranian phone number", nameof(value));

            Value = value.Trim();
        }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
