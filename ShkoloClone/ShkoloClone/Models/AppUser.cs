using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShkoloClone.Enums;

namespace ShkoloClone.Models
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public AppUserEnum UserType { get; set; }

        // Parameterless constructor for JSON deserialization
        public AppUser()
        {
            Id = Guid.NewGuid();
            Username = string.Empty;
            PasswordHash = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            UserType = AppUserEnum.Student;
        }

        public AppUser(string username, string passwordhash, string firstname, string lastname, string phonenumber, string address)
        {
            Id = Guid.NewGuid();
            Username = username;
            PasswordHash = passwordhash;
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phonenumber;
            Address = address;
            UserType = AppUserEnum.Student;
        }
    }
}
