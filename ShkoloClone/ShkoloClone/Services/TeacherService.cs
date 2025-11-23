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
        /// Gets a teacher by id
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>Result containing the teacher if found, or an error message</returns>
        public Result<AppUser> GetTeacherById(Guid teacherId)
        {
            AppUser teacher = _dbContext.Users.FirstOrDefault(x => x.Id == teacherId);
            if (teacher == null)
            {
                return Result<AppUser>.Failure("Teacher not found.");
            }
            return Result<AppUser>.Success("Teacher found", teacher);
        }

        /// <summary>
        /// Gets all teachers
        /// </summary>
        /// <returns>List of all teachers</returns>
        public List<AppUser> GetAllTeachers()
        {
            return _dbContext.Users.Where(x => x.UserType == Enums.AppUserEnum.Teacher).ToList();
        }

        /// <summary>
        /// Gets all classes taught by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>List of classes taught by the teacher</returns>
        public List<Class> GetTeacherClasses(Guid teacherId)
        {
            return _dbContext.Classes.Where(x => x.TeacherId == teacherId).ToList();
        }

        /// <summary>
        /// Gets all students taught by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>List of all students taught by the teacher</returns>
        public List<AppUser> GetTeacherStudents(Guid teacherId)
        {
             return _dbContext.Users.Where(x => x.UserType == Enums.AppUserEnum.Student).Where(x => _dbContext.Classes.Where(y => y.TeacherId == teacherId) ==
            _dbContext.Classes.Where(x => x.Students.Contains(_dbContext.Users.FirstOrDefault(x=>x.Id == teacherId).Id))).ToList();
        }

        /// <summary>
        /// Gets all students in a class taught by the teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="classId">The class id</param>
        /// <returns>Result containing the list of students if the teacher teaches the class, or an error message</returns>
        public Result<List<AppUser>> GetStudentsInTeacherClass(Guid teacherId, Guid classId)
        {
            List<AppUser> appUsers = _dbContext.Users.Where(x => x.UserType == Enums.AppUserEnum.Student).Where(x => _dbContext.Classes.Where(x => x.Id == classId).Where(x => x.TeacherId == teacherId) == _dbContext.Classes.Where(x => x.Students.Contains(_dbContext.Users.FirstOrDefault(x => x.Id == teacherId).Id))).ToList();

            Result<List<AppUser>> result = Result<List<AppUser>>.Success("All Students gotten!", appUsers);
            return result;
        }

        /// <summary>
        /// Adds a grade for a student in a class taught by the teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="studentId">The student id</param>
        /// <param name="value">The grade value</param>
        /// <param name="subject">The subject name</param>
        /// <returns>Result containing the grade id on success, or an error message</returns>
        public Result<Guid> AddGradeForStudent(Guid studentId, Guid teacherId, double value, string subject)
        {
            if (studentId == Guid.Empty)
            {
                return Result<Guid>.Failure("Empty studentId");
            }
            if (_dbContext.Users.FirstOrDefault(x => x.Id ==  studentId) == null)
            {
                return Result<Guid>.Failure("Student doesn't exist!");
            }
            if (value > 6 || value < 2)
            {
                return Result<Guid>.Failure("Grade cannot be below a 2.00 (F) and above a 6.00 (A)");
            }
            Grade grade = new Grade(studentId,teacherId, value, subject);
            _dbContext.Grades.Add(grade);
            _dbContext.SaveChanges();
            Result<Guid> result = Result<Guid>.Success("Grade added succesfully!", grade.Id);
            return result;
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
            foreach (Guid user in  _dbContext.Classes.FirstOrDefault(x => x.Id == classId).Students)
            {
                if (!AddGradeForStudent(user, teacherId, value ,subject).IsSuccess)
                {
                    return Result.Failure("Can't add grade to student");
                }
            }
            return Result.Success("All grades added successfully");
            
        }

        /// <summary>
        /// Gets all grades given by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>List of all grades given by the teacher</returns>
        public List<Grade> GetGradesByTeacher(Guid teacherId)
        {
            List<Grade> grades = _dbContext.Grades.Where(x => x.TeacherId == teacherId).ToList();
            return grades;
        }

        /// <summary>
        /// Gets all grades for a subject given by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="subject">The subject name</param>
        /// <returns>List of grades for the subject</returns>
        public List<Grade> GetGradesByTeacherAndSubject(Guid teacherId, string subject)
        {
            return _dbContext.Grades.Where(x => x.Subject == subject).Where(x => x.TeacherId == teacherId).ToList();
        }
    }
}

