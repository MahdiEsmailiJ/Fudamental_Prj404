using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fudamental_Prj404.Models
{
    internal class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
        public uint Age
        {
            get
            {
                var today = DateTime.Today;
                var age = (uint)(today.Year - BirthDate.Year);
                if (BirthDate > today.AddYears(-(int)age)) age--;
                return age;
            }
        }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        //public User(string firstName, string lastName, string email, string password)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    Password = password;
        //}
        //public uint Age => 
        public override string ToString()
        {
            return $"FullName: {FullName}, Email: {Email}";
        }
        public bool CheckPassword(string password)
        {
            return Password == password;
        }
        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (CheckPassword(oldPassword))
            {
                Password = newPassword;
            }
            else
            {
                throw new Exception("Old password is incorrect");
            }
        }
        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }
    }
}
