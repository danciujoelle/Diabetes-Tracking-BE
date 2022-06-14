using DiabetesTrackingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabetesTrackingServer.Mappers;
using DiabetesTrackingServer.ViewModels;
using DiabetesTrackingServer.DataAccess;
using Microsoft.EntityFrameworkCore;
using DiabetesTrackingServer.Common;

namespace DiabetesTrackingServer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DiabetesTrackingContext _dbContext;

        public UserRepository(DiabetesTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void DeleteUser(Guid id)
        {
            var existingUser = await _dbContext.Users.Where(user => user.UserId == id).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                _dbContext.Users.Remove(existingUser);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            var value = CommonMethods.DecryptData(user.Password);
            if(value == password)
            {
                return user;
            }
            return null;
        }

        public async Task<User> InsertUser(UserModel userEntity)
        {
            var user = userEntity.MapToDataEntity();
            var result = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> IsUsernameUnique(string username)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (existingUser != null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (existingUser != null)
            {
                return false;
            }
            return true;
        }

        public async Task<string> UpdateUser(UpdateUserModel userEntity)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userEntity.UserId);

            if (result != null)
            {
                result.Email = userEntity.Email;
                result.Username = userEntity.Username;
                result.HasDiabetes = userEntity.HasDiabetes;
                result.DiabetesType = userEntity.DiabetesType;
                _dbContext.SaveChanges();
                return "The user was updated successfully";
            }

            return null;
        }

        public async Task<string> UpdatePassword(Guid userId, string newPassword)
        {
            var existingUser = await _dbContext.Users.FindAsync(userId);

            if (existingUser != null)
            {
                existingUser.Password = CommonMethods.EncryptData(newPassword);
                _dbContext.SaveChanges();
                return "The password was updated successfully";
            }

            return "User provided does not exist.";
        }
    }
}
