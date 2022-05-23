using DiabetesTrackingServer.Core.IRepositories;
using DiabetesTrackingServer.DataAccess;
using DiabetesTrackingServer.Mappers;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiabetesTrackingServer.DTOs;

namespace DiabetesTrackingServer.Core.Repositories
{
    public class EventRepository : IEventRepository
    {
        private DiabetesTrackingContext _dbContext;

        public EventRepository(DiabetesTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EventDto>> GetAllEvents(User user)
        {
            return await _dbContext.Events.Where(e => e.User == user).Select(e => new EventDto()
            {
                Title = e.Title,
                Description = e.Description,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
            }).ToListAsync();
        }

        public async Task<EventDto> InsertEvent(EventModel eventEntity, User user)
        {
            var appointment = eventEntity.MapToDataEntity(user);
            var result = await _dbContext.Events.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();
            return new EventDto()
            {
                Title = result.Entity.Title,
                Description = result.Entity.Description,
                StartTime = result.Entity.StartTime,
                EndTime = result.Entity.EndTime
            };
        }
    }
}
