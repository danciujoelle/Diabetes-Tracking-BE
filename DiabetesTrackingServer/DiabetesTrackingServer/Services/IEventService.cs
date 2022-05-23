using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEvents(User user);
        Task<EventDto> InsertEvent(EventModel eventEntity, User user);
    }
}
