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
    public class GlucoseLogRepository : IGlucoseLogRepository
    {
        private DiabetesTrackingContext _dbContext;

        public GlucoseLogRepository(DiabetesTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<GlucoseDto>> GetAllLogs(User user)
        {
            var today = DateTime.Today;
            var currentMonth = today.Month;

            return await _dbContext.GlucoseLogs.Where(e => e.User == user && e.LoggedDate.Month >= currentMonth-2).Select(e => new GlucoseDto()
            {
                GlucoseLevel = e.GlucoseLevel,
                LoggedDate = e.LoggedDate,
                WhenWasLogged = e.WhenWasLogged,
                Notes = e.Notes
            }).ToListAsync();
        }

        public async Task<GlucoseLog> InsertLog(GlucoseLogModel glucoseLogEntity, User user)
        {
            var log = glucoseLogEntity.MapToDataEntity(user);
            var result = await _dbContext.GlucoseLogs.AddAsync(log);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
     
        }

        public bool NeedsReminder(User user)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var result = _dbContext.GlucoseLogs.Where(e => e.User == user && e.LoggedDate >= today && e.LoggedDate < tomorrow).FirstOrDefault();
            if(result != null)
            {
                return false;
            }
            return true;
        }
    }
}
