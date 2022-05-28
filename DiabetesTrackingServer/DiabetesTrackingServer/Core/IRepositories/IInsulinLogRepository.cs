using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Core.IRepositories
{
    public interface IInsulinLogRepository
    {
        Task<IEnumerable<InsulinDto>> GetAllLogs(User user);
        Task<InsulinLog> InsertLog(InsulinLogModel insulinLogEntity, User user);
    }
}
