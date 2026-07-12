using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.Tests.VOTests.User
{
    public class AddressTest
    {
        [Fact]
        public void Address_Should_Create_When_Data_Is_Valid()
        {
            // Arrange
            var province = "Tehran";
            var city = "Tehran";
            var street = "Valiasr St.";
            var postalCode = "1234567890";
            // Act
            var address = new Address(province, city, street, postalCode);
            // Assert
            Assert.Equal(province, address.Province);
            Assert.Equal(city, address.City);
            Assert.Equal(street, address.Street);
            Assert.Equal(postalCode, address.PostalCode);
        }
        [Fact]
        public void Address_Should_Throw_When_Province_Is_Empty()
        {
            // Arrange
            var province = "";
            var city = "Tehran";
            var street = "Valiasr St.";
            var postalCode = "1234567890";
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Address(province, city, street, postalCode));
        }
        [Fact]
        public void Address_Should_Throw_When_City_Is_Empty()
        {
            // Arrange
            var province = "Tehran";
            var city = "";
            var street = "Valiasr St.";
            var postalCode = "1234567890";
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Address(province, city, street, postalCode));
        }
        [Fact]
        public void Address_Should_Throw_When_Street_Is_Empty()
        {
            // Arrange
            var province = "Tehran";
            var city = "Tehran";
            var street = "";
            var postalCode = "1234567890";
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Address(province, city, street, postalCode));
        }
        [Fact]
        public void Address_Should_Throw_When_PostalCode_Is_Empty()
        {
            // Arrange
            var province = "Tehran";
            var city = "Tehran";
            var street = "Valiasr St.";
            var postalCode = ""; // Empty postal code
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Address(province, city, street, postalCode));
        }
        [Fact]
        public void Address_Should_Throw_When_PostalCode_Is_Invalid()
        {
            // Arrange
            var province = "Tehran";
            var city = "Tehran";
            var street = "Valiasr St.";
            var postalCode = "123"; // Invalid postal code
            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Address(province, city, street, postalCode));
        }
        [Fact]
        public void Address_Should_Be_Equal_When_Values_Are_Same()
        {
            // Arrange
            var province = "Tehran";
            var city = "Tehran";
            var street = "Valiasr St.";
            var postalCode = "1234567890";
            var address1 = new Address(province, city, street, postalCode);
            var address2 = new Address(province, city, street, postalCode);
            // Act and Assert
            Assert.Equal(address1, address2);
        }
        [Fact]
        public void Address_Should_Not_Be_Equal_When_Values_Are_Different()
        {
            // Arrange
            var address1 = new Address("Tehran", "Tehran", "Valiasr St.", "1234567890");
            var address2 = new Address("Tehran", "Tehran", "Enghelab St.", "1234567890");
            // Act and Assert
            Assert.NotEqual(address1, address2);
        }
        [Fact]
        public void Address_Should_Have_Same_HashCode_When_Values_Are_Same()
        {
            // Arrange
            var address1 = new Address("Tehran", "Tehran", "Valiasr St.", "1234567890");
            var address2 = new Address("Tehran", "Tehran", "Valiasr St.", "1234567890");
            // Act
            var hashCode1 = address1.GetHashCode();
            var hashCode2 = address2.GetHashCode();
            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

    }
}
