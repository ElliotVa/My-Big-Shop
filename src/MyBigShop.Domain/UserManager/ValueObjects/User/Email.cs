using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyBigShop.Domain.UserManager.ValueObjects.User
{
    public class Email : ValueObject
    {
        public string Value { get; }
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "Email cannot be empty");

            value = value.Trim();

            if (value.Length < 5 || value.Length > 254)
                throw new ArgumentException("Email must be between 5 and 254 characters", nameof(value));

            var at = value.IndexOf('@');
            if (at <= 0 || at == value.Length - 1)
                throw new ArgumentException("Email must contain a single @ with non-empty local and domain parts", nameof(value));

            var local = value[..at];
            var domain = value[(at + 1)..];

            if (local.Length > 64)
                throw new ArgumentException("Local part must be 64 characters or fewer", nameof(value));

            if (local.StartsWith(".") || local.EndsWith(".") || local.Contains(".."))
                throw new ArgumentException("Local part has invalid dot placement", nameof(value));

            if (domain.Length > 255)
                throw new ArgumentException("Domain must be 255 characters or fewer", nameof(value));

            var labels = domain.Split('.');
            if (labels.Length < 2)
                throw new ArgumentException("Domain must contain at least one dot", nameof(value));

            foreach (var label in labels)
            {
                if (label.Length == 0 || label.Length > 63)
                    throw new ArgumentException("Each domain label must be between 1 and 63 characters", nameof(value));
                if (label.StartsWith("-") || label.EndsWith("-"))
                    throw new ArgumentException("Domain labels cannot start or end with a hyphen", nameof(value));
                if (!Regex.IsMatch(label, @"^[A-Za-z0-9-]+$"))
                    throw new ArgumentException("Domain contains invalid characters", nameof(value));
            }

            // Basic local-part allowed chars check (practical, not full RFC)
            if (!Regex.IsMatch(local, @"^[A-Za-z0-9!#$%&'*+/=?^_`{|}~.-]+$"))
                throw new ArgumentException("Local part contains invalid characters", nameof(value));

            // TLD minimal check
            if (labels[^1].Length < 2)
                throw new ArgumentException("Top-level domain must be at least 2 characters", nameof(value));

            Value = value;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}