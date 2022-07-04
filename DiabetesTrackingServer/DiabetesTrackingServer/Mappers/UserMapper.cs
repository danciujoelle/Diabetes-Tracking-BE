using DiabetesTrackingServer.Common;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;

namespace DiabetesTrackingServer.Mappers
{
    public static class UserMapper
    {
        public static User MapToDataEntity(this UserModel user)
        {
            return new User
            {
                UserId = new Guid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Username = user.Username,
                Password = CommonMethods.EncryptData(user.Password),
                HasDiabetes = true,
                DiabetesType = "PrediabetesML",
            };
        }
    }
}
