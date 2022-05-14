using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.Repositories;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void DeleteUser(Guid userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<User> GetUserByUsernameAndPassword(string userName, string password)
        {
            return await _userRepository.GetUserByUsernameAndPassword(userName, password);
        }

        public async Task<User> InsertUser(UserModel userEntity)
        {
            return await _userRepository.InsertUser(userEntity);
        }

        public async Task<bool> IsUsernameUnique(string username)
        {
            return await _userRepository.IsUsernameUnique(username);
        }

        public async Task<User> UpdateUser(UserModel userEntity)
        {
            return await _userRepository.UpdateUser(userEntity);
        }
    }
}
