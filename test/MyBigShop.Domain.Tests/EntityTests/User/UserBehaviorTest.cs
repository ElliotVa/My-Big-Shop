using MyBigShop.Domain.UserManager.Entities.User;
using MyBigShop.Domain.UserManager.Events.DomainEvents;
using MyBigShop.Domain.UserManager.ValueObjects;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.Tests.EntityTests.User
{
    public class UserBehaviorTest
    {
        [Fact]
        public void User_Should_Create_When_Data_Is_Valid()
        {
            // Arrange
            var email = new Email("Alireza@Gmail.Com");
            var phoneNumber = new PhoneNumber("09123456789");
            var userName = new UserName("Alireza5");
            int verificationHistory = 0;
            string verificationBy = string.Empty;
            DateTime? lastlogin = null ;
            DateTime? updatedAt = null;
            // Act
            var user = new Users(email, phoneNumber, userName);
            //Assert
            Assert.NotEqual(Guid.Empty, user.Id);
            Assert.Equal(lastlogin , user.LastLogin);
            Assert.Equal(updatedAt , user.UpdatedAt);
            Assert.Equal(verificationBy , user.VerificationBy);
            Assert.Equal(email, user.Email);
            Assert.Equal(phoneNumber, user.PhoneNumber);
            Assert.Equal(userName, user.UserName);
            Assert.Equal(verificationHistory, user.HistoryOfInactivity);
            Assert.True(user.IsActive);
            Assert.False(user.Verification);
            Assert.False(user.InActive);
            Assert.False(user.IsCompletedProfile);
            Assert.False(user.Suspended);

            Assert.NotEqual(default(DateTime), user.CreatedAt);
        }
        private static Users CreateUser()
        {
            return new Users(
                new Email("mahdi@gmail.com"),
                new PhoneNumber("09123456789"),
                new UserName("Mahdi18"));
        }

        [Fact]
        public void ChangeUserEmail_Should_Update_Email()
        {
            var user = CreateUser();
            var email = new Email("new@gmail.com");

            user.ChangeUserEmail(email);

            Assert.Equal(email, user.Email);
            Assert.NotNull(user.UpdatedAt);
            Assert.Contains(user.Events, e => e is UserChangeEmailEvent);
        }

        [Fact]
        public void ChangeUserPhoneNumber_Should_Update_PhoneNumber()
        {
            var user = CreateUser();
            var phone = new PhoneNumber("09999999999");

            user.ChangeUserPhoneNumber(phone);

            Assert.Equal(phone, user.PhoneNumber);
            Assert.NotNull(user.UpdatedAt);
            Assert.Contains(user.Events, e => e is UserChangePhoneNumberEvent);
        }

        [Fact]
        public void ChangeUserName_Should_Update_UserName()
        {
            var user = CreateUser();
            var userName = new UserName("Ali18");

            user.ChangeUserName(userName);

            Assert.Equal(userName, user.UserName);
            Assert.NotNull(user.UpdatedAt);
            Assert.Contains(user.Events, e => e is UserChangeNameEvent);
        }

        [Fact]
        public void VerifyUser_Should_Set_Verification()
        {
            var user = CreateUser();

            user.VerifyUser("Admin");

            Assert.True(user.Verification);
            Assert.Equal("Admin", user.VerificationBy);
            Assert.NotNull(user.UpdatedAt);
            Assert.Contains(user.Events, e => e is UserVerifiedEvent);
        }

        [Fact]
        public void VerifyUser_Should_Throw_When_VerifiedBy_Is_Empty()
        {
            var user = CreateUser();

            Assert.Throws<ArgumentNullException>(() => user.VerifyUser(""));
        }

        [Fact]
        public void CompleteProfile_Should_Set_IsCompletedProfile()
        {
            var user = CreateUser();

            user.CompleteProfile();

            Assert.True(user.IsCompletedProfile);
            Assert.Contains(user.Events, e => e is UserCompletedProfileEvant);
        }

        [Fact]
        public void DeactivateUser_Should_Deactivate_User()
        {
            var user = CreateUser();

            user.DeactivateUser();

            Assert.False(user.IsActive);
            Assert.True(user.InActive);
            Assert.Contains(user.Events, e => e is UserDeactivatedEvent);
        }

        [Fact]
        public void ActivateUser_Should_Activate_User()
        {
            var user = CreateUser();

            user.DeactivateUser();

            user.ActivateUser();

            Assert.True(user.IsActive);
            Assert.False(user.InActive);
            Assert.Contains(user.Events, e => e is UserActivatedEvent);
        }

        [Fact]
        public void IncrementInactivityHistory_Should_Increment_Count()
        {
            var user = CreateUser();

            user.IncrementInactivityHistory();

            Assert.Equal(1, user.HistoryOfInactivity);
            Assert.Contains(user.Events, e => e is UserInactivityHistoryIncrementedEvent);
        }

        [Fact]
        public void SuspendUser_Should_Set_Suspended()
        {
            var user = CreateUser();

            user.SuspendUser();

            Assert.True(user.Suspended);
            Assert.Contains(user.Events, e => e is UserSuspendedEvent);
        }

        [Fact]
        public void UnSuspendUser_Should_Clear_Suspended()
        {
            var user = CreateUser();

            user.SuspendUser();

            user.UnSuspendUser();

            Assert.False(user.Suspended);
            Assert.Contains(user.Events, e => e is UserUnSuspendedEvent);
        }

        [Fact]
        public void UpdateLastLogin_Should_Update_LastLogin()
        {
            var user = CreateUser();

            user.UpdateLastLogin();

            Assert.NotNull(user.LastLogin);
            Assert.NotNull(user.UpdatedAt);
            Assert.Contains(user.Events, e => e is UserLastLoginUpdatedEvent);
        }

    }
}
