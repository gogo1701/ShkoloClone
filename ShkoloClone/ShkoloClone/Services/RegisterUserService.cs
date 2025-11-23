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
        private  ApplicationDbContext _dbContext;

        public RegisterUserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Register(string userName, string email, string password, string firstName, string lastName, string phoneNumber, string? address, AppUserEnum appUserType)
        { 
            if (appUserType == AppUserEnum.Student)
            {
                Student student = new Student(userName, email, password, firstName, lastName, phoneNumber, address);
            }
            else
            {
                Teacher teacher = new Teacher(userName, email, password, firstName, lastName, phoneNumber, address);
                _dbContext.SaveChanges();
            }
        }
    }
}
