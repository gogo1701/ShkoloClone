using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Student : AppUser
    {
        public Student(string userName, string email, string password, string firstName, string lastName,string phone, string? address)
        {
            Id = Guid.NewGuid();
            Username = userName;
            PasswordHash = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phone;
            Address = address;
            Grades = new List<Grade>();
        }
        public List<Grade> Grades { get; set; }
    }
}
