using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DiabetesTrackingServer.ViewModels
{
    public class InsulinLog
    {
        [Key, Required]
        public Guid InsulinLogId { get; set; }
        [Required]
        public float InsulinIntake { get; set; }

        [Required]
        public DateTime LoggedDate { get; set; }

        [Required]
        public string WhenWasInjected { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }

        public User User { get; set; }
    }
}
