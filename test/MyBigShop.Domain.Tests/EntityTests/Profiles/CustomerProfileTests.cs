using MyBigShop.Domain.UserManager.Entities.Profiles;
using MyBigShop.Domain.UserManager.Entities.User;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.Tests.EntityTests.Profiles
{
    public class CustomerProfileTests
    {
        private static CustomerProfile CreateCustomer()
        {
            var user = new Users(new Email("Alireza@Gmail.Com"), new PhoneNumber("09123456789"), new UserName("Alireza5"));
            var personal = new PersonalInfo("Ali", "Mahdi", "Male", "avatars/profile.png", new DateTime(2003, 12, 16));
            return new CustomerProfile(user, personal);
        }
        [Fact]
        public void CustomerProfile_Should_Create_When_Data_Is_Valid()
        {
            // Arrange
            var profile = CreateCustomer();
            //Act & Assert
            Assert.NotEqual(Guid.Empty, profile.Id);
            Assert.NotEqual(Guid.Empty, profile.UserId);
            Assert.NotNull(profile.PersonalInfo);
            Assert.True(profile.CreatedAt <= DateTime.Now);
        }
        [Fact]
        public void UpdatePersonal_Should_Update_PersonalInfo()
        {
            // Arrange
            var profile = CreateCustomer();
            var newPersonalInfo = new PersonalInfo("Ali", "Mahdi", "Male", "avatars/profile.png", new DateTime(2003, 12, 16));
            //Act & Assert
            profile.UpdatePersonal(newPersonalInfo);

            // Assert
            Assert.Equal(newPersonalInfo, profile.PersonalInfo);
        }
    }
}
