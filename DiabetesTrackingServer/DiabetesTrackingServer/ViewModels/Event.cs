using System;
using System.ComponentModel.DataAnnotations;

namespace DiabetesTrackingServer.ViewModels
{ 
    public class Event
    {
        [Key, Required]
        public Guid EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public User User { get; set; }
    }
}
