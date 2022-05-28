using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Core.IRepositories
{
    public interface ISportLogRepository
    {
        Task<IEnumerable<SportDto>> GetAllLogs(User user);
        Task<SportLog> InsertLog(SportLogModel sportLogEntity, User user);
    }
}
