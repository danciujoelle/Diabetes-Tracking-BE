using System;

namespace DiabetesTrackingServer.Models
{
    public class EventModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string UserId { get; set; }
    }
}
