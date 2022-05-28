using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.DTOs
{
    public class InsulinDto
    {
        public float InsulinInjected { get; set; }
        public DateTime LoggedDate { get; set; }
        public string WhenWasInjected { get; set; }
        public string Notes { get; set; }
    }
}
