using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;

namespace DiabetesTrackingServer.Mappers
{
    public static class GlucoseLogMapper
    {
        public static GlucoseLog MapToDataEntity(this GlucoseLogModel glucoseLog, User user)
        {
            return new GlucoseLog
            {
                GlucoseLogId = new Guid(),
                GlucoseLevel = glucoseLog.GlucoseLevel,
                LoggedDate = DateTime.Now,
                WhenWasLogged = glucoseLog.WhenWasLogged,
                Notes = glucoseLog.Notes,
                User = user,
            };
        }
    }
}
