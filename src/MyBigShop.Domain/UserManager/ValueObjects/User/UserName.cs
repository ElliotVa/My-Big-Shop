using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.ValueObjects.User
{
    public class UserName: ValueObject

    {
        public string Value { get; }

        public UserName (string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "User name cannot be empty");
            if(value.Length <3 || value.Length > 20 )
                throw new ArgumentException("User name must be between 3 and 20 characters", nameof(value));
            if(value.Any(char.IsWhiteSpace))
                throw new ArgumentException("User name cannot contain whitespace", nameof(value));
            if(!value.Any(char.IsDigit))
                throw new ArgumentException("User name must contain at least one digit", nameof(value));
            if (!value.Any(char.IsUpper))
                throw new ArgumentException("User name must contain at least one letter", nameof(value));
            Value = value.Trim();
        }
        
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
}
}
