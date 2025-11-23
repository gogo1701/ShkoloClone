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
        /// Creates a new student account
        /// </summary>
        /// <param name="username">The username for the student</param>
        /// <param name="password">The password for the student</param>
        /// <param name="firstName">The first name of the student</param>
        /// <param name="lastName">The last name of the student</param>
        /// <param name="phoneNumber">The phone number of the student</param>
        /// <param name="address">The address of the student (optional)</param>
        /// <returns>Result containing the created student ID on success, or an error message on failure</returns>
        public Result<Guid> CreateStudent(string username, string password, string firstName, string lastName, string phoneNumber, string? address);

        /// <summary>
        /// Gets a student by id
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the student if found, or an error message</returns>
        public Result<AppUser> GetStudentById(Guid studentId);

        /// <summary>
        /// Gets all students
        /// </summary>
        /// <returns>List of all students</returns>
        public List<AppUser> GetAllStudents();

        /// <summary>
        /// Gets all students in a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <returns>List of students in the class</returns>
        public List<AppUser> GetStudentsByClass(Guid classId);

        /// <summary>
        /// Gets all grades for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>List of grades for the student</returns>
        public List<Grade> GetStudentGrades(Guid studentId);

        /// <summary>
        /// Gets all grades for a student grouped by subject
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Dictionary of subjects with their grades</returns>
        public Dictionary<string, List<Grade>> GetStudentGradesBySubject(Guid studentId);

        /// <summary>
        /// Calculates average grade for a student in a subject
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result containing the average grade, or an error message</returns>
        public Result<double> GetStudentAverageBySubject(Guid studentId, string subject);

        /// <summary>
        /// Calculates overall average grade for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the overall average, or an error message</returns>
        public Result<double> GetStudentOverallAverage(Guid studentId);

        /// <summary>
        /// Gets the class that a student belongs to
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the class if found, or an error message</returns>
        public Result<Class> GetStudentClass(Guid studentId);

        /// <summary>
        /// Gets the teacher of a student's class
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the teacher if found, or an error message</returns>
        public Result<AppUser> GetStudentTeacher(Guid studentId);

        /// <summary>
        /// Updates student profile
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <param name="firstName">First name (null to keep existing)</param>
        /// <param name="lastName">Last name (null to keep existing)</param>
        /// <param name="phoneNumber">Phone number (null to keep existing)</param>
        /// <param name="address">Address (null to keep existing)</param>
        /// <returns>Result indicating success or failure</returns>
        public Result UpdateStudentProfile(Guid studentId, string? firstName, string? lastName, string? phoneNumber, string? address);

        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result DeleteStudent(Guid studentId);
    }
}

