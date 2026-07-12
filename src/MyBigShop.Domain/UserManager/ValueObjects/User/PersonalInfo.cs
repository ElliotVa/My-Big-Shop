using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyBigShop.Domain.UserManager.ValueObjects.User
{
    public class PersonalInfo : ValueObject
    {
        private static readonly Regex NameRegex = new(@"^[\p{L} \-']{1,50}$", RegexOptions.Compiled);
        private static readonly HashSet<string> AllowedGenders = new(StringComparer.OrdinalIgnoreCase)
        {
            "Male", "Female", "Other", "Unspecified"
        };
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string Gender { get; }
        public string? AvatarPath { get; }

        public PersonalInfo (string firstName , string lastName , string gender , string avatar , DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));
            firstName = firstName.Trim();
            if (!NameRegex.IsMatch(firstName))
                throw new ArgumentException("First name contains invalid characters or is too long.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));
            lastName = lastName.Trim();
            if (!NameRegex.IsMatch(lastName))
                throw new ArgumentException("Last name contains invalid characters or is too long.", nameof(lastName));

            if (birthDate == default)
                throw new ArgumentException("Birth date is required.", nameof(birthDate));
            if (birthDate > DateTime.Today)
                throw new ArgumentException("Birth date cannot be in the future.", nameof(birthDate));
            var age = DateTime.Today.Year - birthDate.Year;
            if (birthDate.Date > DateTime.Today.AddYears(-age)) age--;
            if (age < 0 || age > 120)
                throw new ArgumentException("Birth date results in an invalid age.", nameof(birthDate));

            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("Gender cannot be null or empty.", nameof(gender));
            gender = gender.Trim();
            if (!AllowedGenders.Contains(gender))
                throw new ArgumentException("Gender value is not allowed.", nameof(gender));

            string? avatarPath = null;
            if (!string.IsNullOrWhiteSpace(avatar))
            {
                avatar = avatar.Trim();
                if (avatar.Length > 500)
                    throw new ArgumentException("Avatar path is too long.", nameof(avatar));
                avatarPath = avatar;
            }

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            AvatarPath= avatar;
            BirthDate = birthDate;

        }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return BirthDate;
            yield return Gender;
            yield return AvatarPath;
        }
    }
    
}
