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
        /// Adds a grade for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <param name="value">The grade value</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result containing the grade id on success, or an error message</returns>
        public Result<Guid> AddGrade(Guid studentId, double value, string subject);

        /// <summary>
        /// Adds a grade to all students in a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <param name="value">The grade value</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result indicating success or failure</returns>
        public Result AddGradeToClass(Guid classId, double value, string subject);

        /// <summary>
        /// Updates a grade
        /// </summary>
        /// <param name="gradeId">The grade id</param>
        /// <param name="newValue">The new grade value</param>
        /// <returns>Result indicating success or failure</returns>
        public Result UpdateGrade(Guid gradeId, double newValue);

        /// <summary>
        /// Deletes a grade
        /// </summary>
        /// <param name="gradeId">The grade id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result DeleteGrade(Guid gradeId);

        /// <summary>
        /// Gets a grade by id
        /// </summary>
        /// <param name="gradeId">The grade id</param>
        /// <returns>Result containing the grade if found, or an error message</returns>
        public Result<Grade> GetGradeById(Guid gradeId);

        /// <summary>
        /// Gets all grades for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>List of grades for the student</returns>
        public List<Grade> GetGradesByStudent(Guid studentId);

        /// <summary>
        /// Gets all grades for a student grouped by subject
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Dictionary of subjects with their grades</returns>
        public Dictionary<string, List<Grade>> GetGradesByStudentGroupedBySubject(Guid studentId);

        /// <summary>
        /// Gets all grades for multiple students
        /// </summary>
        /// <param name="studentIds">List of student ids</param>
        /// <returns>Dictionary of students with their grades by subject</returns>
        public Dictionary<AppUser, Dictionary<string, List<Grade>>> GetGradesByStudents(List<Guid> studentIds);

        /// <summary>
        /// Gets all grades for a subject
        /// </summary>
        /// <param name="subject">The subject name</param>
        /// <returns>List of grades for the subject</returns>
        public List<Grade> GetGradesBySubject(string subject);

        /// <summary>
        /// Gets all grades for a subject in a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <param name="subject">The subject name</param>
        /// <returns>List of grades for the subject in the class</returns>
        public List<Grade> GetGradesByClassAndSubject(Guid classId, string subject);

        /// <summary>
        /// Calculates average grade for a student in a subject
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result containing the average grade, or an error message</returns>
        public Result<double> GetAverageGradeBySubject(Guid studentId, string subject);

        /// <summary>
        /// Calculates overall average grade for a student
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the overall average, or an error message</returns>
        public Result<double> GetOverallAverageGrade(Guid studentId);

        /// <summary>
        /// Gets all grades
        /// </summary>
        /// <returns>List of all grades</returns>
        public List<Grade> GetAllGrades();
    }
}

