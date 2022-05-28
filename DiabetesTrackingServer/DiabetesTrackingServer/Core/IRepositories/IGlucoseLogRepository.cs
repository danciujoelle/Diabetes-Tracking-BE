using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Core.IRepositories
{
    public interface IGlucoseLogRepository
    {
        Task<IEnumerable<GlucoseDto>> GetAllLogs(User user);
        Task<GlucoseLog> InsertLog(GlucoseLogModel glucoseLogEntity, User user);
    }
}
