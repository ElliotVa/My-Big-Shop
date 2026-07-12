using MyBigShop.Domain.UserManager.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyBigShop.Domain.UserManager.Entities.Profiles
{
    public class AdminProfile
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public PersonalInfo PersonalInfo { get; private set; }
        public string NationalCode { get; private set; }
        public string EmployeeCode { get; private set; }
        public string Department { get; private set; }
        public Email WorkEmail { get; private set; }
        public PhoneNumber WorkPhone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public AdminProfile(Guid userId,PersonalInfo personalInfo, string nationalCode, string employeeCode, string department, PhoneNumber workPhone = null, Email workEmail = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            PersonalInfo = personalInfo ?? throw new ArgumentException (nameof(personalInfo));
            NationalCode = nationalCode;
            WorkEmail = workEmail;
            Department = department;
            WorkPhone = workPhone;
            EmployeeCode = employeeCode;
            CreatedAt = DateTime.UtcNow;
           
        }
        public void UpdateProfile(PersonalInfo personalInfo)
        {
            PersonalInfo = personalInfo;
        }
        public void UpdateWorkEmail(Email email)
        {
            WorkEmail = email;
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateWorkPhone(PhoneNumber phone)
        {
            WorkPhone = phone;
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateDepartment(string department)
        {
            Department = department;
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateEmployeeCode(string employeeCode)
        {
            EmployeeCode = employeeCode;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
