using ShkoloClone.Data;
using ShkoloClone.Models;
using System;
using System.Collections.Generic;

namespace ShkoloClone.Services
{
    /// <summary>
    /// Service for managing teacher-specific operations
    /// </summary>
    public class TeacherService
    {
        private readonly ApplicationDbContext _dbContext;

        public TeacherService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates a new teacher account
        /// </summary>
        /// <param name="username">The username for the teacher</param>
        /// <param name="password">The password for the teacher</param>
        /// <param name="firstName">The first name of the teacher</param>
        /// <param name="lastName">The last name of the teacher</param>
        /// <param name="phoneNumber">The phone number of the teacher</param>
        /// <param name="address">The address of the teacher (optional)</param>
        /// <returns>Result containing the created teacher ID on success, or an error message on failure</returns>
        public Result<Guid> CreateTeacher(string username, string password, string firstName, string lastName, string phoneNumber, string? address)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a teacher by id
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>Result containing the teacher if found, or an error message</returns>
        public Result<AppUser> GetTeacherById(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all teachers
        /// </summary>
        /// <returns>List of all teachers</returns>
        public List<AppUser> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all classes taught by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>List of classes taught by the teacher</returns>
        public List<Class> GetTeacherClasses(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all students taught by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>List of all students taught by the teacher</returns>
        public List<AppUser> GetTeacherStudents(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all students in a class taught by the teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="classId">The class id</param>
        /// <returns>Result containing the list of students if the teacher teaches the class, or an error message</returns>
        public Result<List<AppUser>> GetStudentsInTeacherClass(Guid teacherId, Guid classId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a grade for a student in a class taught by the teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="studentId">The student id</param>
        /// <param name="value">The grade value</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result containing the grade id on success, or an error message</returns>
        public Result<Guid> AddGradeForStudent(Guid teacherId, Guid studentId, double value, string subject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a grade to all students in a class taught by the teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="classId">The class id</param>
        /// <param name="value">The grade value</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result indicating success or failure</returns>
        public Result AddGradeToClass(Guid teacherId, Guid classId, double value, string subject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all grades given by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>List of all grades given by the teacher</returns>
        public List<Grade> GetGradesByTeacher(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all grades for a subject given by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="subject">The subject name</param>
        /// <returns>List of grades for the subject</returns>
        public List<Grade> GetGradesByTeacherAndSubject(Guid teacherId, string subject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates teacher profile
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="firstName">First name (null to keep existing)</param>
        /// <param name="lastName">Last name (null to keep existing)</param>
        /// <param name="phoneNumber">Phone number (null to keep existing)</param>
        /// <param name="address">Address (null to keep existing)</param>
        /// <returns>Result indicating success or failure</returns>
        public Result UpdateTeacherProfile(Guid teacherId, string? firstName, string? lastName, string? phoneNumber, string? address)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result DeleteTeacher(Guid teacherId)
        {
            throw new NotImplementedException();
        }
    }
}

