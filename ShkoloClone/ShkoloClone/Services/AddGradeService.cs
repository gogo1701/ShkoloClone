using ShkoloClone.Data;
using ShkoloClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Services
{
    public class AddGradeService
    {
        private readonly ApplicationDbContext _dbContext;
        public AddGradeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddGrade(Student student, Grade grade)
        {
            student.Grades.Add(grade);
        }
        public void AddGradeToClass(Class Class, Grade grade)
        {
            foreach (var student in _dbContext.Students.Where(x => Class.students.Contains(x.Id)))
            {
                student.Grades.Add(grade);
            }
        }
    }
    
}
