using System;
using System.Collections.Generic;
using Xunit;
using MyBigShop.Domain.UserManager.ValueObjects;
using System.Text;
using MyBigShop.Domain.UserManager.ValueObjects.User;

namespace MyBigShop.Domain.Tests.VOTests.User
{
    public class EmailTests
    {
        [Fact]
        public void Email_Should_Create_When_Email_Is_Valid()
        {
            // Arrange
            var emailValue = "Alireza@Gmail.com";

            // Act 
            var email = new Email("Alireza@Gmail.com");
            //Assert 
            Assert.Equal(emailValue, email.Value);

        }

        [Fact]
        public void Email_Should_Throw_When_Email_Is_Empty()
        {
            //Arrange
            var email = "";
            //Act and Assert 
            var exception = Assert.Throws<ArgumentNullException>(() => new Email(email));
        }
        [Fact]
        public void Email_Should_Throw_When_Email_Is_Null()
        {
            //Arrange
            string? email = null;
            //Act and Assert 
            Assert.Throws<ArgumentNullException>(() => new Email(email!));
        }
        [Fact]
        public void Email_Should_Throw_When_Email_Has_No_AtSign()
        {
            //Arrange
            var email = "ElliotAligmail.com";
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new Email(email));
        }
        [Fact]
        public void Email_Should_Throw_When_LocalPart_Is_Too_Long()
        {
            //Arrange
            var emailLocal = "" + new string('a', 65) + "@gmail.com";
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new Email(emailLocal));
        }
        [Fact]
        public void Email_Should_Throw_When_Domain_Has_No_Dot()
        {
            //Arrange
            var emailDomain = "Elliot@Aligmailcom";
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new Email(emailDomain));
        }
        [Fact]
        public void Email_Should_Throw_When_Domain_Label_Starts_With_Hyphen()
        {
            //Arrange
            var emailDomain = "Elliot@-Ali.gmail.com";
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new Email(emailDomain));
        }
        [Fact]
        public void Email_Should_Throw_When_Tld_Is_Too_Short()
        {
            //Arrange
            var emailTld = "Elliot@Ali.g";
            //Act and Assert
            Assert.Throws<ArgumentException>(() => new Email(emailTld));
        }
        [Fact]
        //Equal Test
        public void Email_Should_Be_Equal_When_Values_Are_Same()
        {
            //Arrange
            var email1 = new Email("alireza@gmail.com");
            var email2 = new Email("alireza@gmail.com");
            //Act and Assert
            Assert.Equal(email1, email2);
        }
        [Fact]
        //Not Equal Test
        public void Email_Should_Not_Be_Equal_When_Values_Are_Different()
        {
            //Arrange
            var email1 = new Email("mahdi@gmail.com");
            var email2 = new Email("ali@gmail.com");
            //Act and Assert
            Assert.NotEqual(email1, email2);
        }
        [Fact]
        public void Email_With_Same_Value_Should_Have_Same_HashCode()
        {
            //Arrange
            var email1 = new Email("alireza@gmail.com");
            var email2 = new Email("alireza@gmail.com");
            //Act
            var hashCode1 = email1.GetHashCode();
            var hashCode2 = email2.GetHashCode();

            //Assert
            Assert.Equal(hashCode1, hashCode2);
        }
    }
}

