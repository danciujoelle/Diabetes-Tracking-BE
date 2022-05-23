using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Core.IRepositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventDto>> GetAllEvents(User user);
        Task<EventDto> InsertEvent(EventModel eventEntity, User user);
    }
}
