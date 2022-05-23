using DiabetesTrackingServer.Core.IRepositories;
using DiabetesTrackingServer.DTOs;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public class EventService : IEventService
    {
        private IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IEnumerable<EventDto>> GetAllEvents(User user)
        {
            return await _eventRepository.GetAllEvents(user);
        }

        public async Task<EventDto> InsertEvent(EventModel eventEntity, User user)
        {
            return await _eventRepository.InsertEvent(eventEntity, user);
        }
    }
}
