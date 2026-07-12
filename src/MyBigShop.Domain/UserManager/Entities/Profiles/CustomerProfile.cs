using MyBigShop.Domain.UserManager.Entities.User;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyBigShop.Domain.UserManager.Entities.Profiles
{
    public class CustomerProfile
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public PersonalInfo PersonalInfo { get; private set; }
        public string? AvatarPath { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        //Behavior
        public CustomerProfile(Users user ,PersonalInfo personelinfo)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            PersonalInfo = personelinfo; 
            CreatedAt = DateTime.Now;
            user.CompleteProfile();
        }
        public void UpdatePersonal(PersonalInfo personalInfo)
        {
            PersonalInfo = personalInfo;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}  
