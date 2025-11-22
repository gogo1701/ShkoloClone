using ShkoloClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ShkoloClone.Data;

namespace ShkoloClone.Services
{
    public class ReceiveGradesService
    {
        // please figure out a meaningful way to do DI here
        private ApplicationDbContext _dbContext;
        public ReceiveGradesService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public List<Student> GetGradesByClass(Guid classId)
        {
            List<Student> students = new List<Student>();
            return students;
        }
        public List<Grade> GetGradesByStudent(Student student)
        {

            return grades;
        }
    }
}
