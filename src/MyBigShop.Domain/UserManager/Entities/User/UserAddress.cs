using MyBigShop.Domain.UserManager.Entities.Profiles;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.Entities.User
{
    public class UserAddress 
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Address Province {  get; private set; }

        public Address City { get; private set; }
        public Address Street { get; private set; }
        public Address PostalCode { get; private set; }

        public string ReceiverName { get; private set; }
        public string ReceiverPhoneNumber { get; private set; }
        public bool IsDefault { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public UserAddress(Users user , Address province , Address street , Address postalCode , Address city , string receiverName , string receiverPhoneNumber , bool isDefault) 
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            PostalCode = postalCode;
            Province = province;
            Street = street;
            City = city;
            ReceiverName = receiverName;
            ReceiverPhoneNumber = receiverPhoneNumber;
            IsDefault = isDefault;
            CreatedAt = DateTime.UtcNow;
            
        }
    }
}
