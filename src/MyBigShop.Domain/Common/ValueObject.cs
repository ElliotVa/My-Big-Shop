using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Domain.Common
{
    public abstract class ValueObject
    {
        // Create a method that returns an IEnumrable of all the properties of the value object. This method will be used to compare two value objects.\
        //For Example : yield return Value;
        protected abstract IEnumerable<object?> GetEqualityComponents();

        //For Camparing two value objects, we need to compare all the properties of the value object. 
        public override bool Equals(object? obj)
        {
            //obj = email2 or username2 or ...
            if (obj is null || obj.GetType() != GetType())
                return false;
            //other type = ValueObject or ValueObject other = obj
            var other = (ValueObject)obj; 

            return GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        public static bool operator == (ValueObject? left, ValueObject? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject? left, ValueObject? right)
        {
            return !Equals(left, right);
        }
    }
}