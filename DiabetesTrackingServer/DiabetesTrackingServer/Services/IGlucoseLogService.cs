using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public interface IGlucoseLogService
    {
        Task<IEnumerable<GlucoseDto>> GetAllGlucoseLogs(User user);
        Task<GlucoseLog> InsertLog(GlucoseLogModel glucoseLogEntity, User user);
        bool NeedsReminder(User user);
    }
}
