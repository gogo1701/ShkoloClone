using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Teacher : AppUser
    {
        public Teacher(string userName, string email, string password, string firstName, string lastName, string phone, string? address)
        {
            Id = Guid.NewGuid();
            Username = userName;
            PasswordHash = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phone;
            Address = address;
        }
        public List<Class> ClassList { get; set; }
    }
}
