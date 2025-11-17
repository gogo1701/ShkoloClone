using ShkoloClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShkoloClone.Services
{
    public class ReceiveGradesService
    {
        public List<Student> GetGradesByClass()
        {
            List<Student> students = new List<Student>();
            return students;
        }
        public List<Grade> GetGradesByStudent(Student student)
        {
            List<Grade> grades = new List<Grade>();
            return grades;
        }
    }
}
