using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Mappers
{
    public static class EventMapper
    {
        public static Event MapToDataEntity(this EventModel appointment, User user)
        {
            return new Event
            {
                EventId = new Guid(),
                Title = appointment.Title,
                Description = appointment.Description,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                User = user
            };
        }
    }
}
