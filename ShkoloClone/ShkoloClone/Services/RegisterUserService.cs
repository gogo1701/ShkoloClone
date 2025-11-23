using ShkoloClone.Data;
using ShkoloClone.Enums;
using ShkoloClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Services
{
    public class RegisterUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public RegisterUserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid Register(out AppUserEnum appUser)
        {
        
            Console.WriteLine("Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Password:");
            string password = Console.ReadLine();

            Console.WriteLine("FirstName:");
            string firstName = Console.ReadLine();

            Console.WriteLine("LastName:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("(Not Required) Address:");
            string? address = Console.ReadLine();

            Console.WriteLine("student or teacher?");
            string type = Console.ReadLine();
            appUser = AppUserEnum.Admin;
            switch (type)
            {
                case "student": appUser = AppUserEnum.Student; break;
                case "teacher": appUser = AppUserEnum.Student; break;
            }
            if (appUser == AppUserEnum.Student)
            {
                Student student = new Student(username, email, password, firstName, lastName, phoneNumber, address);

                return student.Id;
            }
            else
            {
                Teacher teacher = new Teacher(username, email, password, firstName, lastName, phoneNumber, address);

                return teacher.Id;
            }
            
        }
    }
}
