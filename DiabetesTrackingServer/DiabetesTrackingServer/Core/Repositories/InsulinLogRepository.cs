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
    public class InsulinLogRepository : IInsulinLogRepository
    {
        private DiabetesTrackingContext _dbContext;

        public InsulinLogRepository(DiabetesTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<InsulinDto>> GetAllLogs(User user)
        {
            var today = DateTime.Today;
            var currentMonth = today.Month;

            return await _dbContext.InsulinLogs.Where(e => e.User == user && e.LoggedDate.Month >= currentMonth - 2).Select(e => new InsulinDto()
            {
                InsulinInjected = e.InsulinIntake,
                LoggedDate = e.LoggedDate,
                WhenWasInjected = e.WhenWasInjected,
                Notes = e.Notes
            }).ToListAsync();
        }

        public async Task<InsulinLog> InsertLog(InsulinLogModel insulinLogEntity, User user)
        {
            var log = insulinLogEntity.MapToDataEntity(user);
            var result = await _dbContext.InsulinLogs.AddAsync(log);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public bool NeedsReminder(User user)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var result = _dbContext.InsulinLogs.Where(e => e.User == user && e.LoggedDate >= today && e.LoggedDate < tomorrow).FirstOrDefault();
            if (result != null)
            {
                return false;
            }
            return true;
        }
    }
}
