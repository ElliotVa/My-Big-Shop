using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.ValueObjects.User
{
    public class Address : ValueObject
    {
        public string Province { get; }
        public string City { get; }
        public string Street { get; }
        public string PostalCode { get; }

        public Address(
            string province,
            string city,
            string street,
            string postalCode)
        {
            // Business Rules
            if (string.IsNullOrWhiteSpace(province))
                throw new ArgumentNullException(nameof(province), "Province cannot be empty");
            if(string.IsNullOrWhiteSpace(city))
                throw new ArgumentNullException(nameof(city), "City cannot be empty");
            if(string.IsNullOrWhiteSpace(street))
                throw new ArgumentNullException(nameof(street), "Street cannot be empty");
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentNullException(nameof(postalCode), "Postal code cannot be empty");
            if (postalCode.Length is <10 or >11)
                throw new ArgumentException("Postal code must be 10 digits", nameof(postalCode));

            Province = province;
            City = city;
            Street = street;
            PostalCode = postalCode;
        }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Province;
            yield return City;
            yield return Street;
            yield return PostalCode;
        }
    }
}
