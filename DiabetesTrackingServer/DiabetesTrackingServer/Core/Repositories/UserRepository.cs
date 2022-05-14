using DiabetesTrackingServer.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using DiabetesTrackingServer.Mappers;
using DiabetesTrackingServer.ViewModels;
using DiabetesTrackingServer.DataAccess;
using Microsoft.EntityFrameworkCore;

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
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
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

        public async Task<User> UpdateUser(UserModel userEntity)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == userEntity.Username);

            if (result != null)
            {
                var user = userEntity.MapToDataEntity();
                await _dbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

    }
}
