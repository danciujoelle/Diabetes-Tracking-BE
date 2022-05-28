using DiabetesTrackingServer.Core.IRepositories;
using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public class SportLogService : ISportLogService
    {
        private ISportLogRepository _sportLogRepository;
        public SportLogService(ISportLogRepository sportLogRepository)
        {
            _sportLogRepository = sportLogRepository;
        }
        public async Task<IEnumerable<SportDto>> GetAllSportLogs(User user)
        {
            return await _sportLogRepository.GetAllLogs(user);
        }

        public async Task<SportLog> InsertLog(SportLogModel sportLogEntity, User user)
        {
            return await _sportLogRepository.InsertLog(sportLogEntity, user);
        }
    }
}
