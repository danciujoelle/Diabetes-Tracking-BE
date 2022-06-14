using DiabetesTrackingServer.Core.IRepositories;
using DiabetesTrackingServer.DataAccess;
using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Mappers;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Core.Repositories
{
    public class SportLogRepository : ISportLogRepository
    {
        private DiabetesTrackingContext _dbContext;

        public SportLogRepository(DiabetesTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SportDto>> GetAllLogs(User user)
        {
            var today = DateTime.Today;
            var currentMonth = today.Month;

            return await _dbContext.SportLogs.Where(e => e.User == user && e.LoggedDate.Month >= currentMonth - 2).Select(e => new SportDto()
            {
                Duration = e.Duration,
                LoggedDate = e.LoggedDate,
                TypeOfActivity = e.TypeOfActivity,
                Notes = e.Notes
            }).ToListAsync();
        }

        public async Task<SportLog> InsertLog(SportLogModel sportLogEntity, User user)
        {
            var log = sportLogEntity.MapToDataEntity(user);
            var result = await _dbContext.SportLogs.AddAsync(log);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
