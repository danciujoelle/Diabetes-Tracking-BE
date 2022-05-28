using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.DTOs
{
    public class GlucoseDto
    {
        public float GlucoseLevel { get; set; }
        public DateTime LoggedDate { get; set; }
        public string WhenWasLogged { get; set; }
        public string Notes { get; set; }
    }
}
