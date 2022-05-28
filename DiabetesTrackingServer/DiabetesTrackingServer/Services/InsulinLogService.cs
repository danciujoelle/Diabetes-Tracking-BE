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
    public class InsulinLogService : IInsulinLogService
    {
        private IInsulinLogRepository _insulinLogRepository;
        public InsulinLogService(IInsulinLogRepository insulinLogRepository)
        {
            _insulinLogRepository = insulinLogRepository;
        }

        public async Task<IEnumerable<InsulinDto>> GetAllInsulinLogs(User user)
        {
            return await _insulinLogRepository.GetAllLogs(user);
        }

        public async Task<InsulinLog> InsertLog(InsulinLogModel insulinLogEntity, User user)
        {
            return await _insulinLogRepository.InsertLog(insulinLogEntity, user);
        }
    }
}
