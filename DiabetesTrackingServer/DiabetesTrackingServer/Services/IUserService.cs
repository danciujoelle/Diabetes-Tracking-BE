using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> InsertUser(UserModel userEntity);
        Task<User> UpdateUser(UserModel userEntity);
        void DeleteUser(Guid userId);
        Task<User> GetUserById(Guid userId);
        Task<User> GetUserByUsernameAndPassword(string userName, string password);
        Task<Boolean> IsUsernameUnique(string username);
    }
}
