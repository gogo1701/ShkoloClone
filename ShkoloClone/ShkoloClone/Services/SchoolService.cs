using ShkoloClone.Data;
using ShkoloClone.Models;
using System;
using System.Collections.Generic;

namespace ShkoloClone.Services
{
    /// <summary>
    /// Service for managing schools in the system
    /// </summary>
    public class SchoolService
    {
        private readonly ApplicationDbContext _dbContext;

        public SchoolService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates a new school
        /// </summary>
        /// <param name="schoolName">The name of the school</param>
        /// <param name="schoolWebsite">The website URL of the school</param>
        /// <param name="roomNames">List of room names in the school</param>
        /// <returns>Result containing the created school ID on success, or an error message on failure</returns>
        public Result<Guid> CreateSchool(string schoolName, string? schoolWebsite)
        {
            School school = new School(schoolName, schoolWebsite);
            _dbContext.Schools.Add(school);
            _dbContext.SaveChanges();
            return Result<Guid>.Success("School created successfully", school.Id);
        }

        /// <summary>
        /// Gets a school by id
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <returns>Result containing the school if found, or an error message</returns>
        public Result<School> GetSchoolById(Guid schoolId)
        {
            School school = _dbContext.Schools.FirstOrDefault(x => x.Id == schoolId);
            if (school == null)
            {
                Result<School>.Failure("School not found!");
            }
            return Result<School>.Success("School found!", school);
        }

        /// <summary>
        /// Gets all schools
        /// </summary>
        /// <returns>List of all schools</returns>
        public List<School> GetAllSchools()
        {
            return _dbContext.Schools.ToList();
        }

        /// <summary>
        /// Updates school information
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <param name="schoolName">School name (null to keep existing)</param>
        /// <param name="schoolWebsite">Website URL (null to keep existing)</param>
        /// <returns>Result indicating success or failure</returns>
        public Result UpdateSchool(Guid schoolId, string? schoolName, string? schoolWebsite)
        {
            School school = _dbContext.Schools.FirstOrDefault(x => x.Id == schoolId);
            if (schoolId != null)
            {
                school.Id  = schoolId;
            }
            if (schoolName != null)
            {
                school.SchoolName = schoolName;
            }
            if (schoolWebsite != null)
            {
                school.SchoolWebsite = schoolWebsite;
            }
            return Result.Success("Successfully updated school");
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Adds a class to a school
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <param name="classId">The class id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result AddClassToSchool(Guid schoolId, Guid classId)
        {
            Class Class = new Class(classId);
            if (_dbContext.Schools.FirstOrDefault(x => x.Id == schoolId) == null)
            {
                return Result.Failure("School not found");
            }
            _dbContext.Schools.FirstOrDefault(x => x.Id == schoolId).ClassList.Add(Class);
            _dbContext.SaveChanges();
            return Result.Success("Class added to school successfully");
        }

        /// <summary>
        /// Removes a class from a school
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <param name="classId">The class id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result RemoveClassFromSchool(Guid schoolId, Guid classId)
        {
            Class Class = _dbContext.Classes.FirstOrDefault(x => x.Id ==  classId);

            if (Class == null)
            {
                return Result.Failure("Class doesn't exist");
            }
            _dbContext.Schools.FirstOrDefault(x => x.Id == schoolId).ClassList.Remove(Class);
            _dbContext.SaveChanges();
            return Result.Success("Class removed successfully");


        }

        /// <summary>
        /// Adds a room to a school
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <param name="roomName">The room name</param>
        /// <returns>Result indicating success or failure</returns>
        public Result AddRoomToSchool(Guid schoolId, string roomName)
        {
            if (_dbContext.Schools.FirstOrDefault(x => x.Id == schoolId) == null)
            {
                return Result.Failure("School doesn't exist");
            }
            _dbContext.Schools.FirstOrDefault(x => x.Id == schoolId).Rooms.Add(roomName);
            _dbContext.SaveChanges();
            return Result.Success("Successfully added room to school");
            
        }

        /// <summary>
        /// Removes a room from a school
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <param name="roomName">The room name</param>
        /// <returns>Result indicating success or failure</returns>
        public Result RemoveRoomFromSchool(Guid schoolId, string roomName)
        {
            if (_dbContext.Schools.FirstOrDefault(x => x.Id == schoolId) == null)
            {
                return Result.Failure("School doesn't exist");
            }
            if (!_dbContext.Schools.FirstOrDefault(x => x.Id == schoolId).Rooms.Contains(roomName))
            {
                return Result.Failure("School doesn't have that room");
            }
            _dbContext.Schools.FirstOrDefault(x => x.Id == schoolId).Rooms.Remove(roomName);
            _dbContext.SaveChanges();
            return Result.Success("Successfully removed room");
        }

        /// <summary>
        /// Gets all classes in a school
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <returns>List of classes in the school</returns>
        public List<Class> GetClassesInSchool(Guid schoolId)
        {
            return _dbContext.Schools.FirstOrDefault(x => x.Id == schoolId).ClassList;
        }

        /// <summary>
        /// Gets all rooms in a school
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <returns>List of room names</returns>
        public List<string> GetRoomsInSchool(Guid schoolId)
        {
            return _dbContext.Schools.FirstOrDefault(x => x.Id == schoolId).Rooms;
        }

        /// <summary>
        /// Deletes a school
        /// </summary>
        /// <param name="schoolId">The school id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result DeleteSchool(Guid schoolId)
        {
            if (_dbContext.Schools.FirstOrDefault(x => x.Id==schoolId) == null)
            {
                return Result.Failure("School doesn't exist");
            }
            _dbContext.Schools.Remove(_dbContext.Schools.FirstOrDefault(x => x.Id == schoolId));
            _dbContext.SaveChanges();
            return Result.Success("School successfully removed");
        }
    }
}

