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

        // done
        private readonly ApplicationDbContext _dbContext;
        public ReceiveGradesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Dictionary<Student, Dictionary<string, List<Grade>>> GetGradesByClass(List<Guid> students)
        {
            var classStudents = _dbContext.Students
                .Where(s => students.Contains(s.Id))
                .ToList();

            Dictionary<Student, Dictionary<string, List<Grade>>> gradesByClass1 =
            classStudents.ToDictionary(
            student => student,
            student => _dbContext.Grades
            .Where(g => g.studentId == student.Id)
            .GroupBy(g => g.Subject)               
            .ToDictionary(
                grp => grp.Key,                  
                grp => grp.ToList()      
                ));


            foreach (var studentEntry in gradesByClass1)
            {
                var student = studentEntry.Key;
                var subjects = studentEntry.Value;

                Console.WriteLine($"Student: {student.Username}");

                foreach (var subjectEntry in subjects)
                {
                    var subjectName = subjectEntry.Key;
                    var grades = subjectEntry.Value;

                    Console.WriteLine($"  Subject: {subjectName}");

                    foreach (var grade in grades)
                    {
                        Console.WriteLine(grade.Id + " " + grade.Value);
                    }
                }

                Console.WriteLine();
            }
            return gradesByClass1;
        }
        public List<Grade> GetGradesByStudent(Student student)
        {
            var grades = _dbContext.Grades
                .Where(x => x.studentId == student.Id)
                .ToList();

            Console.WriteLine($"Grades for {student.Username}:");

            var grouped = grades
                .GroupBy(g => g.Subject)
                .ToDictionary(
                    grp => grp.Key,
                    grp => grp.Select(x => x.Value).ToList()
                );
            foreach (var subject in grouped)
            {
                string gradeList = string.Join(", ", subject.Value);
                Console.WriteLine($"{subject.Key}: {gradeList}");
            }

            return grades;
        }


    }
}
