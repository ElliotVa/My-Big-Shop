using MyBigShop.Domain.UserManager.ValueObjects;
using MyBigShop.Domain.UserManager.ValueObjects.User;
using Xunit;

namespace MyBigShop.Domain.Tests.VOTests
{
    public class PersonalInfoTests
    {
        [Fact]
        public void PersonalInfo_Should_Create_When_Data_Is_Valid()
        {
            // Arrange
            var firstName = "Mahdi";
            var lastName = "Moradi";
            var gender = "Male";
            var avatar = "avatars/profile.png";
            var birthDate = new DateTime(2003, 12, 16);

            // Act
            var personalInfo = new PersonalInfo(
                firstName,
                lastName,
                gender,
                avatar,
                birthDate);

            // Assert
            Assert.Equal(firstName, personalInfo.FirstName);
            Assert.Equal(lastName, personalInfo.LastName);
            Assert.Equal(gender, personalInfo.Gender);
            Assert.Equal(avatar, personalInfo.AvatarPath);
            Assert.Equal(birthDate, personalInfo.BirthDate);
        }

        [Fact]
        public void PersonalInfo_Should_Throw_When_FirstName_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
                new PersonalInfo(
                    "",
                    "Moradi",
                    "Male",
                    "",
                    new DateTime(2003, 12, 16)));
        }

        [Fact]
        public void PersonalInfo_Should_Throw_When_LastName_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
                new PersonalInfo(
                    "Mahdi",
                    "",
                    "Male",
                    "",
                    new DateTime(2003, 12, 16)));
        }

        [Fact]
        public void PersonalInfo_Should_Throw_When_FirstName_Is_Invalid()
        {
            Assert.Throws<ArgumentException>(() =>
                new PersonalInfo(
                    "Mahdi123",
                    "Moradi",
                    "Male",
                    "",
                    new DateTime(2003, 12, 16)));
        }

        [Fact]
        public void PersonalInfo_Should_Throw_When_LastName_Is_Invalid()
        {
            Assert.Throws<ArgumentException>(() =>
                new PersonalInfo(
                    "Mahdi",
                    "Moradi@",
                    "Male",
                    "",
                    new DateTime(2003, 12, 16)));
        }

        [Fact]
        public void PersonalInfo_Should_Throw_When_BirthDate_Is_Default()
        {
            Assert.Throws<ArgumentException>(() =>
                new PersonalInfo(
                    "Mahdi",
                    "Moradi",
                    "Male",
                    "",
                    default));
        }

        [Fact]
        public void PersonalInfo_Should_Throw_When_BirthDate_Is_In_Future()
        {
            Assert.Throws<ArgumentException>(() =>
                new PersonalInfo(
                    "Mahdi",
                    "Moradi",
                    "Male",
                    "",
                    DateTime.Today.AddDays(1)));
        }

        [Fact]
        public void PersonalInfo_Should_Throw_When_Gender_Is_Invalid()
        {
            Assert.Throws<ArgumentException>(() =>
                new PersonalInfo(
                    "Mahdi",
                    "Moradi",
                    "Robot",
                    "",
                    new DateTime(2003, 12, 16)));
        }

        [Fact]
        public void PersonalInfo_Should_Create_When_Gender_Is_Different_Case()
        {
            var personalInfo = new PersonalInfo(
                "Mahdi",
                "Moradi",
                "male",
                "",
                new DateTime(2003, 12, 16));

            Assert.Equal("male", personalInfo.Gender);
        }

        [Fact]
        public void PersonalInfo_Should_Create_When_Avatar_Is_Empty()
        {
            var personalInfo = new PersonalInfo(
                "Mahdi",
                "Moradi",
                "Male",
                null,
                new DateTime(2003, 12, 16));

            Assert.Null(personalInfo.AvatarPath);
        }

        [Fact]
        public void PersonalInfo_Should_Throw_When_Avatar_Is_Too_Long()
        {
            var avatar = new string('A', 501);

            Assert.Throws<ArgumentException>(() =>
                new PersonalInfo(
                    "Mahdi",
                    "Moradi",
                    "Male",
                    avatar,
                    new DateTime(2003, 12, 16)));
        }

        [Fact]
        public void PersonalInfo_Should_Be_Equal_When_Values_Are_Same()
        {
            var info1 = new PersonalInfo(
                "Mahdi",
                "Moradi",
                "Male",
                "",
                new DateTime(2003, 12, 16));

            var info2 = new PersonalInfo(
                "Mahdi",
                "Moradi",
                "Male",
                "",
                new DateTime(2003, 12, 16));

            Assert.Equal(info1, info2);
        }

        [Fact]
        public void PersonalInfo_Should_Have_Same_HashCode_When_Values_Are_Same()
        {
            var info1 = new PersonalInfo(
                "Mahdi",
                "Moradi",
                "Male",
                "",
                new DateTime(2003, 12, 16));

            var info2 = new PersonalInfo(
                "Mahdi",
                "Moradi",
                "Male",
                "",
                new DateTime(2003, 12, 16));

            Assert.Equal(info1.GetHashCode(), info2.GetHashCode());
        }

        [Fact]
        public void PersonalInfo_Should_Not_Be_Equal_When_Values_Are_Different()
        {
            var info1 = new PersonalInfo(
                "Mahdi",
                "Moradi",
                "Male",
                "",
                new DateTime(2003, 12, 16));

            var info2 = new PersonalInfo(
                "Ali",
                "Ahmadi",
                "Male",
                "",
                new DateTime(2000, 1, 1));

            Assert.NotEqual(info1, info2);
        }
    }
}