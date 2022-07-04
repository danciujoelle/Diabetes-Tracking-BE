using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> InsertUser(UserModel userEntity);
        Task<string> UpdateUser(UpdateUserModel userEntity);
        void DeleteUser(Guid userId);
        Task<User> GetUserById(Guid userId);
        Task<User> GetUserByUsernameAndPassword(string userName, string password);
        Task<Boolean> IsUsernameUnique(string username);
        Task<Boolean> IsEmailUnique(string email);

        Task<string> UpdatePassword(Guid userId, string newPassword);

    }
}
