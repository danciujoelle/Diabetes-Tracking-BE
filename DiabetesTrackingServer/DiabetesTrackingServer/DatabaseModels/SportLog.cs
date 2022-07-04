using System;
using System.ComponentModel.DataAnnotations;

namespace DiabetesTrackingServer.ViewModels
{
    public class SportLog
    {
        [Key, Required]
        public Guid SportLogId { get; set; }
        [Required]
        public float Duration { get; set; }

        [Required]
        public DateTime LoggedDate { get; set; }

        [Required]
        public string TypeOfActivity { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }

        public User User { get; set; }
    }
}
