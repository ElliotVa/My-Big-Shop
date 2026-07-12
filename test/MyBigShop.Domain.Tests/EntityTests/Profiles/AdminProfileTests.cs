using MyBigShop.Domain.UserManager.Entities.Profiles;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using Xunit;

namespace MyBigShop.Domain.Tests.EntityTests.Profile
{
    public class AdminProfileTests
    {
        private static PersonalInfo CreatePersonalInfo()
        {
            return new PersonalInfo(
                "Mahdi",
                "Moradi",
                "Male",
                "",
                new DateTime(2003, 12, 16));
        }

        private static AdminProfile CreateAdmin()
        {
            return new AdminProfile(
                Guid.NewGuid(),
                CreatePersonalInfo(),
                "1234567890",
                "EMP001",
                "IT",
                new PhoneNumber("09123456789"),
                new Email("admin@bigshop.com"));
        }

        [Fact]
        public void AdminProfile_Should_Create_When_Data_Is_Valid()
        {
            // Arrange & Act
            var admin = CreateAdmin();

            // Assert
            Assert.NotEqual(Guid.Empty, admin.Id);
            Assert.NotEqual(Guid.Empty, admin.UserId);
            Assert.Equal("1234567890", admin.NationalCode);
            Assert.Equal("EMP001", admin.EmployeeCode);
            Assert.Equal("IT", admin.Department);
            Assert.NotNull(admin.WorkEmail);
            Assert.NotNull(admin.WorkPhone);
            Assert.NotNull(admin.PersonalInfo);
        }

        [Fact]
        public void UpdateProfile_Should_Update_PersonalInfo()
        {
            // Arrange
            var admin = CreateAdmin();

            var newInfo = new PersonalInfo(
                "Ali",
                "Ahmadi",
                "Male",
                "",
                new DateTime(2000, 1, 1));

            // Act
            admin.UpdateProfile(newInfo);

            // Assert
            Assert.Equal(newInfo, admin.PersonalInfo);
        }

        [Fact]
        public void UpdateWorkEmail_Should_Update_Email()
        {
            // Arrange
            var admin = CreateAdmin();
            var email = new Email("newadmin@bigshop.com");

            // Act
            admin.UpdateWorkEmail(email);

            // Assert
            Assert.Equal(email, admin.WorkEmail);
            Assert.True(admin.UpdatedAt > DateTime.MinValue);
        }

        [Fact]
        public void UpdateWorkPhone_Should_Update_Phone()
        {
            // Arrange
            var admin = CreateAdmin();
            var phone = new PhoneNumber("09999999999");

            // Act
            admin.UpdateWorkPhone(phone);

            // Assert
            Assert.Equal(phone, admin.WorkPhone);
            Assert.True(admin.UpdatedAt > DateTime.MinValue);
        }

        [Fact]
        public void UpdateDepartment_Should_Update_Department()
        {
            // Arrange
            var admin = CreateAdmin();

            // Act
            admin.UpdateDepartment("Finance");

            // Assert
            Assert.Equal("Finance", admin.Department);
            Assert.True(admin.UpdatedAt > DateTime.MinValue);
        }

        [Fact]
        public void UpdateEmployeeCode_Should_Update_EmployeeCode()
        {
            // Arrange
            var admin = CreateAdmin();

            // Act
            admin.UpdateEmployeeCode("EMP999");

            // Assert
            Assert.Equal("EMP999", admin.EmployeeCode);
            Assert.True(admin.UpdatedAt > DateTime.MinValue);
        }
    }
}