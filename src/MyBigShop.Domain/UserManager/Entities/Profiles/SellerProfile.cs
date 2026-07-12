using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.Entities.Profiles
{
    public class SellerProfile
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public PersonalInfo PersonalInfo { get; private set; }
        public string ShopName { get; private set; }
        public string? ShopDescription { get; private set; }
        public string? ShopLogo { get; private set; }

        public bool IsPending { get; private set; }
        public bool IsRejected { get; private set; }
        public bool IsVerified { get; private set; }
        public DateTime? VerifiedAt { get; private set; }

        public Email BusinessEmail { get; private set; }
        public PhoneNumber BusinessPhoneNumber { get; private set; }

        public double Rating { get; private set; }
        public int TotalSales { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
