using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public interface IInsulinLogService
    {
        Task<IEnumerable<InsulinDto>> GetAllInsulinLogs(User user);
        Task<InsulinLog> InsertLog(InsulinLogModel insulinLogEntity, User user);
        bool NeedsReminder(User user);
    }
}
