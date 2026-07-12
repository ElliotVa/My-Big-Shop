using MyBigShop.Domain.UserManager.ValueObjects;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.Tests.VOTests.User
{
    public class UserNameTests
    {
        [Fact]
        public void UserName_Should_Create_When_Is_Valid()
        {
            var validUserName = "Mahdi18J";

            var userName = new UserName(validUserName);

            Assert.Equal(validUserName, userName.Value);
        }
        [Fact]
        public void UserName_Should_Have_Same_HashCode_When_Values_Are_Same()
        {
            // Arrange
            var userName1 = new UserName("Mahdi18j");
            var userName2 = new UserName("Mahdi18j");
            // Act
            var hashCode1 = userName1.GetHashCode();
            var hashCode2 = userName2.GetHashCode();
            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }
        [Fact]
        public void UserName_Should_Not_Be_Equal_When_Values_Are_Different()
        {
            // Arrange
            var userName1 = new UserName("Mahdi18J");
            var userName2 = new UserName("Mahdi18j");
            // Act & Assert
            Assert.NotEqual(userName1, userName2);
        }
        [Fact]
        public void UserName_Should_Throw_When_Is_Empty()
        {
            // Arrange
            var emptyUserName = "";
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new UserName(emptyUserName));
        }
        [Fact]
        public void UserName_Should_Throw_When_Is_Null()
        {
            // Arrange
            string? nullUserName = null;
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new UserName(nullUserName!));
        }
        [Fact]
        public void UserName_Should_Throw_When_Has_Invalid_Length()
        {
            // Arrange
            var invalidLengthUserName = "kddjkfga" ; // 10 character
            // Act and Assert

            Assert.Throws<ArgumentException>(() => new UserName(invalidLengthUserName));
        }
        [Fact]
        public void UserName_Should_Throw_When_Has_No_Uppercase_Letter()
        {
            // Arrange
            var invalidCharactersUserName = "mahdimoradi";
            // Act and Assert
            Assert.Throws<ArgumentException>(() => new UserName(invalidCharactersUserName));
        }
        [Fact]
        public void UserName_Should_Throw_When_Contains_Spaces()
        {
            // Arrange
            var validUserName = "Mahdi 183";
            // Assert
            Assert.Throws<ArgumentException>(() => new UserName(validUserName));
        }
        [Fact]
        public void UserName_Should_Throw_When_Has_Special_Characters()
        {
            // Arrange
            var invalidCharactersUserName = "Mahdi 183";
            // Act and Assert
            Assert.Throws<ArgumentException>(() => new UserName(invalidCharactersUserName));
        }
        [Fact]
        public void UserName_Should_Throw_When_Has_Only_Numbers()
        {
            // Arrange
            var invalidCharactersUserName = "123456789";
            // Act and Assert
            Assert.Throws<ArgumentException>(() => new UserName(invalidCharactersUserName));
        }
    }
}
