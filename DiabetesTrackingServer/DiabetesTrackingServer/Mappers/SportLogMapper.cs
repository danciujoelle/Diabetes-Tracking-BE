using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;

namespace DiabetesTrackingServer.Mappers
{
    public static class SportLogMapper
    {
        public static SportLog MapToDataEntity(this SportLogModel sportLog, User user)
        {
            return new SportLog
            {
                SportLogId = new Guid(),
                Duration = sportLog.Duration,
                LoggedDate = DateTime.Now,
                TypeOfActivity = sportLog.TypeOfActivity,
                Notes = sportLog.Notes,
                User = user
            };
        }
    }
}
