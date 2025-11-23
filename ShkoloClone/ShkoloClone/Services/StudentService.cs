using ShkoloClone.Data;
using ShkoloClone.Models;
using System;
using System.Collections.Generic;

namespace ShkoloClone.Services
{
    /// <summary>
    /// Service for managing student-specific operations
    /// </summary>
    public class StudentService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets a student by id
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the student if found, or an error message</returns>
        public Result<AppUser> GetStudentById(Guid studentId)
        {
            AppUser user = _dbContext.Users.FirstOrDefault(x => x.Id == studentId);
            if (user == null)
            {
                return Result<AppUser>.Failure("Student doesn't exist");
            }
            return Result<AppUser>.Success("Student Found!", user);
        }

        /// <summary>
        /// Gets all students
        /// </summary>
        /// <returns>List of all students</returns>
        public List<AppUser> GetAllStudents()
        {
            return _dbContext.Users.Where(x => x.UserType == Enums.AppUserEnum.Student).ToList();
        }

        /// <summary>
        /// Gets all students in a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <returns>List of students in the class</returns>
        public List<AppUser> GetStudentsByClass(Guid classId)
        {
            var classObj = _dbContext.Classes.FirstOrDefault(x => x.Id == classId);
            if (classObj == null || classObj.Students == null)
            {
                return new List<AppUser>();
            }
            return classObj.Students
                .Select(studentId => _dbContext.Users.FirstOrDefault(user => user.Id == studentId))
                .Where(user => user != null)
                .ToList();
        }

        /// <summary>
        /// Gets all grades for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>List of grades for the student</returns>
        public List<Grade> GetStudentGrades(Guid studentId)
        {
            return _dbContext.Grades.Where(x => x.StudentId == studentId).ToList();
        }

        /// <summary>
        /// Gets all grades for a student grouped by subject
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Dictionary of subjects with their grades</returns>
        public Dictionary<string, List<Grade>> GetStudentGradesBySubject(Guid studentId)
        {
            return _dbContext.Grades.Where(x => x.StudentId == studentId).GroupBy(x => x.Subject).ToDictionary(group => group.Key, group => group.ToList());
        }

        /// <summary>
        /// Calculates average grade for a student in a subject
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result containing the average grade, or an error message</returns>
        public Result<double> GetStudentAverageBySubject(Guid studentId, string subject)
        {
            double result = _dbContext.Grades.Where(x => x.StudentId == studentId).Where(x => x.Subject == subject).Sum(x => x.Value) / _dbContext.Grades.Where(x => x.StudentId == studentId).Where(x => x.Subject == subject).Count();

            if (result > 6.00 || result < 2.00)
            {
                return Result<double>.Failure("Sum isn't correct");
            }
            if (_dbContext.Users.FirstOrDefault(x => x.Id == studentId) != null)
            {
                return Result<double>.Failure("Student doesn't exist");
            }
            return Result<double>.Success("Average completed", result);
        }

        /// <summary>
        /// Calculates overall average grade for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the overall average, or an error message</returns>
        public Result<double> GetStudentOverallAverage(Guid studentId)
        {
            double result = _dbContext.Grades.Where(x => x.StudentId == studentId).Sum(x => x.Value) / _dbContext.Grades.Where(x => x.StudentId == studentId).Count();

            if (result > 6.00 || result < 2.00)
            {
                return Result<double>.Failure("Sum isn't correct");
            }
            if (_dbContext.Users.FirstOrDefault(x => x.Id == studentId) != null)
            {
                return Result<double>.Failure("Student doesn't exist");
            }
            return Result<double>.Success("Average completed", result);
        }

        /// <summary>
        /// Gets the class that a student belongs to
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the class if found, or an error message</returns>
        public Result<Class> GetStudentClass(Guid studentId)
        {
            Class Class = _dbContext.Classes.FirstOrDefault(x => x.Students.Contains(_dbContext.Users.FirstOrDefault(x => x.Id == studentId).Id));
            if (Class == null)
            {
                return Result<Class>.Failure("Class doesn't exist");
            }
            if (_dbContext.Users.FirstOrDefault(x => x.Id == studentId) == null)
            {
                return Result<Class>.Failure("Student doesn't exist");
            }
            return Result<Class>.Success("Class found", Class);
        }

        /// <summary>
        /// Gets the teacher of a student's class
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the teacher if found, or an error message</returns>
        public Result<AppUser> GetStudentTeacher(Guid studentId)
        {
            Class Class = _dbContext.Classes.FirstOrDefault(x => x.Students.Contains(_dbContext.Users.FirstOrDefault(x => x.Id == studentId).Id));
            if(Class == null)
            {
                return Result<AppUser>.Failure("Class doesn't exist");
            }
            if (_dbContext.Users.FirstOrDefault(x => x.Id == studentId) == null)
            {
                return Result<AppUser>.Failure("Student doesn't exist");
            }
            AppUser user = _dbContext.Users.FirstOrDefault(x => x.Id == Class.TeacherId);
            return Result<AppUser>.Success("Teacher found!", user);
        }
    }
}

