using MyBigShop.Domain.UserManager.ValueObjects;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using Xunit;

namespace MyBigShop.Domain.Tests.VOTests.User
{
    public class PhoneNumberTests
    {
        [Fact]
        public void Should_Create_PhoneNumber_When_Equal_Value()
        {
            //Arrange
            var validPhoneNumber = "09123456789";
            //Act
            var phoneNumberVO = new PhoneNumber("09123456789");
            //Assert
            Assert.Equal(validPhoneNumber, phoneNumberVO.Value);
        }
        [Fact]
        public void Should_Create_PhoneNumber_When_HashCode_Is_Equal()
        {
            //Arrange
            var PhoneNumber = "09123456789";
            var PhoneNumber2 = "09123456789";
            //Act
            var phoneNumberVO = new PhoneNumber(PhoneNumber);
            var phoneNumberVO2 = new PhoneNumber(PhoneNumber2);
            //Assert
            Assert.Equal(phoneNumberVO.GetHashCode(), phoneNumberVO2.GetHashCode());
        }
        [Fact]
        public void Should_Throw_Exception_When_PhoneNumber_Is_Empty()
        {
            //Arrange
            var emptyPhoneNumber = "";
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new PhoneNumber(emptyPhoneNumber));
        }
        [Fact]
        public void Should_Throw_Exception_When_PhoneNumber_Is_Null()
        {
            //Arrange
            string? nullPhoneNumber = null;
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new PhoneNumber(nullPhoneNumber!));
        }
        [Fact]
        public void Should_Throw_Exception_When_PhoneNumber_Has_Invalid_NationalCode()
        {
            //Arrange
            var invalidNationalCodePhoneNumber = "08123456789";
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new PhoneNumber(invalidNationalCodePhoneNumber));
        }
        [Fact]
        public void Should_Throw_Exception_When_PhoneNumber_Has_Invalid_Length()
        {
            //Arrange
            var invalidLengthPhoneNumber = "0912345678"; // 9 digits
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new PhoneNumber(invalidLengthPhoneNumber));
        }
        [Fact]
        public void Should_Throw_Exception_When_PhoneNumber_Has_Only_NationalCode()
        {
            //Arrange
            var onlyNationalCodePhoneNumber = "09"; // Only national code
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new PhoneNumber(onlyNationalCodePhoneNumber));
        }
        [Fact]
        public void Should_Throw_Exception_When_PhoneNumber_Has_Extra_Characters()
        {
            //Arrange
            var extraCharactersPhoneNumber = "091234567890"; // 12 digits
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new PhoneNumber(extraCharactersPhoneNumber));
        }
        [Fact]
        public void Should_Throw_Exception_When_PhoneNumber_Has_Special_Characters()
        {
            //Arrange
            var specialCharactersPhoneNumber = "09123@#$%6789"; // 11 digits but contains special characters
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new PhoneNumber(specialCharactersPhoneNumber));
        }

    }
}
