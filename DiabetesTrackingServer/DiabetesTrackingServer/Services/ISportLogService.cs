using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public interface ISportLogService
    {
        Task<IEnumerable<SportDto>> GetAllSportLogs(User user);
        Task<SportLog> InsertLog(SportLogModel sportLogEntity, User user);
    }
}
