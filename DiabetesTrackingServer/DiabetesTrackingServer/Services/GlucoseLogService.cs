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
    public class GlucoseLogService : IGlucoseLogService
    {
        private IGlucoseLogRepository _glucoseLogRepository;
        public GlucoseLogService(IGlucoseLogRepository glucoseLogRepository)
        {
            _glucoseLogRepository = glucoseLogRepository;
        }
        public async Task<IEnumerable<GlucoseDto>> GetAllGlucoseLogs(User user)
        {
            return await _glucoseLogRepository.GetAllLogs(user);
        }

        public async Task<GlucoseLog> InsertLog(GlucoseLogModel glucoseLogEntity, User user)
        {
            return await _glucoseLogRepository.InsertLog(glucoseLogEntity, user);
        }

        public bool NeedsReminder(User user)
        {
            return _glucoseLogRepository.NeedsReminder(user);
        }
    }
}
