using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.ViewModels
{
    public class GlucoseLog
    {
        [Key, Required]
        public Guid GlucoseLogId { get; set; }
        [Required]
        public float GlucoseLevel { get; set; }

        [Required]
        public DateTime LoggedDate { get; set; }

        [Required]
        public string WhenWasLogged { get; set; }

        [Required]
        public string Notes { get; set; }

        public User User { get; set; }
    }
}
