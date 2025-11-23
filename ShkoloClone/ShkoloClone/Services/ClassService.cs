using ShkoloClone.Data;
using ShkoloClone.Models;
using System;
using System.Collections.Generic;

namespace ShkoloClone.Services
{
    /// <summary>
    /// Service for managing classes in the system
    /// </summary>
    public class ClassService
    {
        private readonly ApplicationDbContext _dbContext;

        public ClassService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates a new class with a teacher and list of students
        /// </summary>
        /// <param name="teacherId">The id of the teacher assigned to the class</param>
        /// <param name="studentIds">List of student id to add to the class</param>
        /// <returns>Result containing the created class ID on success, or an error message on failure</returns>
        public Result<Guid> CreateClass(Guid teacherId, List<AppUser> students)
        {
            Class Class = new Class(students, teacherId);
            _dbContext.Classes.Add(Class);
            _dbContext.SaveChanges();
            return Result<Guid>.Success("Class created successfully", Class.Id);
        }

        /// <summary>
        /// Gets a class by id
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <returns>Result containing the class if found, or an error message</returns>
        public Result<Class> GetClassById(Guid classId)
        {
            Class Class = _dbContext.Classes.FirstOrDefault(c => c.Id == classId);
            if (_dbContext.Classes.FirstOrDefault(c => c.Id == classId) == null)
            {
                return Result<Class>.Failure("Class doesn't exist");
            }
            return Result<Class>.Success("Class gotten successfully", Class);
        }

        /// <summary>
        /// Gets all classes
        /// </summary>
        /// <returns>List of all classes</returns>
        public List<Class> GetAllClasses()
        {
            return _dbContext.Classes;
        }

        /// <summary>
        /// Gets all classes taught by a teacher
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <returns>List of classes taught by the teacher</returns>
        public List<Class> GetClassesByTeacher(Guid teacherId)
        {
            return _dbContext.Classes.Where(x => x.TeacherId == teacherId).ToList();
        }

        /// <summary>
        /// Gets the class that a student belongs to
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>Result containing the class if found, or an error message</returns>
        public Result<Class> GetClassByStudent(Guid studentId)
        {
            AppUser user = _dbContext.Users.FirstOrDefault(x => x.Id == studentId);
            Class Class = _dbContext.Classes.FirstOrDefault(x => x.Students.Contains(user));
            if (_dbContext.Users.FirstOrDefault(x => x.Id == studentId) == null)
            {
                return Result<Class>.Failure("Student doesn't exist");
            }
            if (Class == null)
            {
                return Result<Class>.Failure("Class doesn't exist");
            }
            return Result<Class>.Success("Class found", Class);
        }

        /// <summary>
        /// Adds a student to a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <param name="studentId">The student id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result AddStudentToClass(Guid classId, Guid studentId)
        {
            if (_dbContext.Users.FirstOrDefault(x => x.Id == studentId) == null)
            {
                return Result.Failure("Student doesn't exist");
            }
            if (_dbContext.Classes.FirstOrDefault(x => x.Id == classId) == null)
            {
                return Result.Failure("Class doesn't exist");
            }
            AppUser user = _dbContext.Users.FirstOrDefault(y => y.Id == studentId);
            _dbContext.Classes.FirstOrDefault(x => x.Id == studentId).Students.Add(user);
            _dbContext.SaveChanges();
            return Result.Success("Student added successfully");
        }

        /// <summary>
        /// Removes a student from a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <param name="studentId">The student id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result RemoveStudentFromClass(Guid classId, Guid studentId)
        {
            if (_dbContext.Users.FirstOrDefault(x => x.Id == studentId) == null)
            {
                return Result.Failure("Student doesn't exist");
            }
            if (_dbContext.Classes.FirstOrDefault(x => x.Id == classId) == null)
            {
                return Result.Failure("Class doesn't exist");
            }
            AppUser user = _dbContext.Users.FirstOrDefault(y => y.Id == studentId);
            _dbContext.Classes.FirstOrDefault(x => x.Id == studentId).Students.Remove(user);
            _dbContext.SaveChanges();
            return Result.Success("Student added successfully");
        }

        /// <summary>
        /// Updates the teacher assigned to a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <param name="newTeacherId">The new teacher id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result UpdateClassTeacher(Guid classId, Guid newTeacherId)
        {
            if (_dbContext.Classes.FirstOrDefault(x => x.Id == classId) == null)
            {
                return Result.Failure("Class doesn't exist");
            }
            _dbContext.Classes.FirstOrDefault(x => x.Id == classId).TeacherId = newTeacherId;
            _dbContext.SaveChanges();
            return Result.Success("Teacher updated successfully");

        }

        /// <summary>
        /// Replaces all students in a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <param name="studentIds">New list of student ids</param>
        /// <returns>Result indicating success or failure</returns>
        public Result UpdateClassStudents(Guid classId, List<Guid> studentIds)
        {
            if (_dbContext.Classes.FirstOrDefault(x => x.Id == classId) == null)
            {
                return Result.Failure("Class doesn't exist");
            }
            if (studentIds.Count == 0)
            {
                return Result.Failure("Class is empty");
            }
            List<AppUser> users = new List<AppUser>();
            foreach (var id  in studentIds)
            {
                users.Add(_dbContext.Users.FirstOrDefault(x => x.Id == id));
            }
            _dbContext.Classes.FirstOrDefault(x => x.Id == classId).Students = users;
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result DeleteClass(Guid classId)
        {
            if (_dbContext.Classes.FirstOrDefault(x => x.Id == classId) == null)
            {
                return Result.Failure("Class doesn't exist");
            }
            Class Class = _dbContext.Classes.FirstOrDefault(x => x.Id == classId);
            _dbContext.Classes.Remove(Class);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Gets all students in a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <returns>List of students in the class</returns>
        public List<AppUser> GetStudentsInClass(Guid classId)
        {
            return _dbContext.Classes.FirstOrDefault(x => x.Id == classId).Students;
        }

        /// <summary>
        /// Gets the teacher assigned to a class
        /// </summary>
        /// <param name="classId">The class id</param>
        /// <returns>Result containing the teacher if found, or an error message</returns>
        public Result<AppUser> GetClassTeacher(Guid classId)
        {
            if (_dbContext.Classes.FirstOrDefault(x => x.Id == classId) == null)
            {
                return Result<AppUser>.Failure("Class doesn't exist");
            }
            Guid teacher = _dbContext.Classes.FirstOrDefault(x => x.Id == classId).TeacherId;
            AppUser user = _dbContext.Users.FirstOrDefault(x => x.Id == teacher);
            return Result<AppUser>.Success("Teacher found", user);
        }
    }
}

