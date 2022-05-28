using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;

namespace DiabetesTrackingServer.Mappers
{
    public static class InsulinLogMapper
    {
        public static InsulinLog MapToDataEntity(this InsulinLogModel insulinLog, User user)
        {
            return new InsulinLog
            {
                InsulinLogId = new Guid(),
                InsulinIntake = insulinLog.InsulinIntake,
                LoggedDate = DateTime.Now,
                WhenWasInjected = insulinLog.WhenWasInjected,
                Notes = insulinLog.Notes,
                User = user
            };
        }
    }
}
