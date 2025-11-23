using ShkoloClone.Data;
using ShkoloClone.Models;
using System;
using System.Collections.Generic;

namespace ShkoloClone.Services
{
    /// <summary>
    /// Service for managing grades in the system
    /// </summary>
    public class GradeService
    {
        private readonly ApplicationDbContext _dbContext;

        public GradeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets a grade by id
        /// </summary>
        /// <param name="gradeId">The grade id</param>
        /// <returns>Result containing the grade if found, or an error message</returns>
        public Result<Grade> GetGradeById(Guid gradeId)
        {
            if (_dbContext.Grades.FirstOrDefault(x => x.Id ==  gradeId) == null)
            {
                return Result<Grade>.Failure("Grade doesn't exist");
            }
            return Result<Grade>.Success("Grade successfully removed");
        }

        /// <summary>
        /// Gets all grades for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>List of grades for the student</returns>
        public List<Grade> GetGradesByStudent(Guid studentId)
        {
            return _dbContext.Grades.Where(x => x.StudentId == studentId).ToList();
        }

        /// <summary>
        /// Gets all grades for a student grouped by subject
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Dictionary of subjects with their grades</returns>
        public Dictionary<string, List<Grade>> GetGradesByStudentGroupedBySubject(Guid studentId)
        {
            return _dbContext.Grades.Where(x => x.StudentId == studentId).GroupBy(x => x.Subject).ToDictionary(group => group.Key, group => group.ToList());
        }

        /// <summary>
        /// Gets all grades for multiple students
        /// </summary>
        /// <param name="studentIds">List of student ids</param>
        /// <returns>Dictionary of students with their grades by subject</returns>
        public Dictionary<AppUser, Dictionary<string, List<Grade>>> GetGradesByStudents(List<Guid> studentIds)
        {
            var students = _dbContext.Users
                .Where(u => studentIds.Contains(u.Id))
                .ToList();

            var grades = _dbContext.Grades
                .Where(g => studentIds.Contains(g.StudentId))
                .ToList();

            var result = new Dictionary<AppUser, Dictionary<string, List<Grade>>>();

            foreach (var student in students)
            {
                var studentGrades = grades
                    .Where(g => g.StudentId == student.Id)
                    .GroupBy(g => g.Subject)
                    .ToDictionary(
                        g => g.Key,
                        g => g.ToList()
                    );
                result.Add(student, studentGrades);
            }

            return result;
        }


        /// <summary>
        /// Gets all grades for a subject
        /// </summary>
        /// <param name="subject">The subject name</param>
        /// <returns>List of grades for the subject</returns>
        public List<Grade> GetGradesBySubject(string subject)
        {
            return _dbContext.Grades.Where(x => x.Subject == subject).ToList();
        }

        /// <summary>
        /// Gets all grades for a subject in a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <param name="subject">The subject name</param>
        /// <returns>List of grades for the subject in the class</returns>
        public List<Grade> GetGradesByClassAndSubject(Guid classId, string subject)
        {
            List<Grade> grades = new List<Grade>();
            var students = _dbContext.Classes.FirstOrDefault(x => x.Id == classId).Students;

            foreach (var student in students)
            {
                List<Grade> studentGrades = _dbContext.Grades
                    .Where(x => x.StudentId == student)
                    .Where(x => x.Subject == subject)
                    .ToList();
                grades.AddRange(studentGrades);
            }

            return grades;
        }

        /// <summary>
        /// Calculates average grade for a student in a subject
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result containing the average grade, or an error message</returns>
        public Result<double> GetAverageGradeBySubject(Guid studentId, string subject)
        {
            double result = _dbContext.Grades.Where(x => x.StudentId == studentId).Where(x => x.Subject == subject).Sum(x => x.Value) / _dbContext.Grades.Where(x => x.StudentId == studentId).Where(x => x.Subject == subject).Count();

            if (result > 6 || result < 2)
            {
                return Result<double>.Failure("Average is not correct");
            }
            return Result<double>.Success("Average is calculated correctly!", result);
        }

        /// <summary>
        /// Calculates overall average grade for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the overall average, or an error message</returns>
        public Result<double> GetOverallAverageGrade(Guid studentId)
        {
            double result = _dbContext.Grades.Where(x => x.StudentId == studentId).Sum(x => x.Value) / _dbContext.Grades.Where(x => x.StudentId == studentId).Count();
            if (result > 6 || result < 2)
            {
                return Result<double>.Failure("Average is not correct");
            }
            return Result<double>.Success("Average is calculated correctly!", result);
        }

        /// <summary>
        /// Gets all grades
        /// </summary>
        /// <returns>List of all grades</returns>
        public List<Grade> GetAllGrades()
        {
            return _dbContext.Grades;
        }
    }
}

