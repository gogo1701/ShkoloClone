using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShkoloClone.Data;
using ShkoloClone.Enums;
using ShkoloClone.Models;

namespace ShkoloClone.Services
{
    public class AccountService
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <returns>Result containing the user id on success, or an error message</returns>
        public Result<Guid> RegisterUser(string username, string password, string firstName, string lastName, string phone, string? address)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return Result<Guid>.Failure("Username cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return Result<Guid>.Failure("Password cannot be empty.");
            }

            if (_dbContext.Users.Any(u => u.Username.Equals(username)))
            {
                return Result<Guid>.Failure("Username already exists. Please choose a different username.");
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                return Result<Guid>.Failure("First name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                return Result<Guid>.Failure("Last name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                return Result<Guid>.Failure("Phone number cannot be empty.");
            }

            try
            {
                var newUser = new AppUser(username, password, firstName, lastName, phone, address ?? string.Empty);
                
                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                return Result<Guid>.Success($"User '{username}' registered successfully!", newUser.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure($"An error occurred during registration: {ex.Message}");
            }
        }

        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>Result containing the user id on success, or an error message</returns>
        public Result<Guid> LoginUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return Result<Guid>.Failure("Username cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return Result<Guid>.Failure("Password cannot be empty.");
            }

            var user = _dbContext.Users.FirstOrDefault(u => u.Username.Equals(username));

            if (user == null)
            {
                return Result<Guid>.Failure("Username does not exist. Please check your username and try again.");
            }

            if (user.PasswordHash != password)
            {
                return Result<Guid>.Failure("Incorrect password. Please try again.");
            }

            return Result<Guid>.Success($"Welcome back, {user.Username}!", user.Id);
        }

        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>Result containing the user if found, or an error message</returns>
        public Result<AppUser> GetUserById(Guid userId);

        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>Result containing the user if found, or an error message</returns>
        public Result<AppUser> GetUserByUsername(string username);

        /// <summary>
        /// Updates user profile
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="firstName">First name (null to keep existing)</param>
        /// <param name="lastName">Last name (null to keep existing)</param>
        /// <param name="phoneNumber">Phone number (null to keep existing)</param>
        /// <param name="address">Address (null to keep existing)</param>
        /// <returns>Result indicating success or failure</returns>
        public Result<AppUser> UpdateUserProfile(Guid userId, string? firstName, string? lastName, string? phoneNumber, string? address);

        /// <summary>
        /// Changes user password
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="oldPassword">Current password</param>
        /// <param name="newPassword">New password</param>
        /// <returns>Result indicating success or failure</returns>
        public Result ChangePassword(Guid userId, string oldPassword, string newPassword);

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>Result indicating success or failure</returns>
        public Result DeleteUser(Guid userId);

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of all users</returns>
        public List<AppUser> GetAllUsers();

        /// <summary>
        /// Gets users by type
        /// </summary>
        /// <param name="userType">The user type</param>
        /// <returns>List of users of the specified type</returns>
        public List<AppUser> GetUsersByType(AppUserEnum userType);

        /// <summary>
        /// Gets the user type by user id
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>Role of user</returns>
        public Result<AppUserEnum> GetUserTypeById(Guid userId);
    }
}
