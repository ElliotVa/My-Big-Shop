using MyBigShop.Domain.UserManager.Events.DomainEvents;
using MyBigShop.Domain.UserManager.Events.Events;
using MyBigShop.Domain.UserManager.Events.IEvents;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyBigShop.Domain.UserManager.Entities.User
{
    public class Users
    {
        public Guid Id { get; private set; }
        public UserName UserName { get; private set; }
        //Vo
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        //State
        public bool IsActive { get; private set; }
        public bool InActive { get; private set; }
        public bool IsCompletedProfile { get; private set; }
        public bool Verification { get; private set; }
        public bool Suspended { get; private set; }
        public int HistoryOfInactivity { get; private set; }
        public string? VerificationBy { get; private set; }
        //Date and Time 
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        //public Roles Roles { get; private set; }


        //Domain Events 
        private readonly List<IDomainEvents> _events = new();

        public IReadOnlyCollection<IDomainEvents> Events
            => _events.AsReadOnly();

        //Behavior
        public Users (  Email email , PhoneNumber phoneNumber , UserName userName)
        {
            Id = Guid.NewGuid();
            Email = email;
            PhoneNumber = phoneNumber;
            UserName = userName;
            IsActive = true;
            InActive = false;
            Suspended = false;
            HistoryOfInactivity = 0;
            VerificationBy = string.Empty;
            LastLogin = null;
            UpdatedAt = null;
            CreatedAt = DateTime.UtcNow;
            IsCompletedProfile = false;
            Verification = false;
            
            _events.Add(new UserCreateEvent(Id));
        }
        public void ChangeUserEmail(Email email)
        {
            Email = email;
            UpdatedAt = DateTime.UtcNow;
            _events.Add(new UserChangeEmailEvent(Id));
        }
        public void ChangeUserPhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
            UpdatedAt = DateTime.UtcNow;
            _events.Add(new UserChangePhoneNumberEvent(Id));
        }
        public void ChangeUserName( UserName userName)
        {
            UpdatedAt = DateTime.UtcNow;
            UserName = userName;
            _events.Add(new UserChangeNameEvent(Id));
        }
        public void VerifyUser(string verifiedBy)
        {
            if (string.IsNullOrWhiteSpace(verifiedBy))
                throw new ArgumentNullException("Verified by cannot be empty", nameof(verifiedBy));
            VerificationBy = verifiedBy;
            Verification = true;
            UpdatedAt = DateTime.UtcNow;
            _events.Add(new UserVerifiedEvent(Id));
        }
        //Verification
        public void CompleteProfile()
        {
            IsCompletedProfile = true;
            _events.Add(new UserCompletedProfileEvant(Id));
        }

        // Bloked and UnBloked
        public void DeactivateUser()
        {
            IsActive = false;
            InActive = true;
            _events.Add(new UserDeactivatedEvent(Id));
        }
        public void ActivateUser()
        {
            IsActive = true;
            InActive = false;
            _events.Add(new UserActivatedEvent(Id));
        }
        public void IncrementInactivityHistory()
        {
            HistoryOfInactivity++;
            _events.Add(new UserInactivityHistoryIncrementedEvent(Id));
        }

        // Suspended and UnSuspended
        public void SuspendUser()
        {
            Suspended = true;
            _events.Add(new UserSuspendedEvent(Id));
        }
        public void UnSuspendUser()
        {
            Suspended = false;
            _events.Add(new UserUnSuspendedEvent(Id));
        }
        public void UpdateLastLogin()
        {
            LastLogin = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            _events.Add(new UserLastLoginUpdatedEvent(Id));
        }
    }
}
