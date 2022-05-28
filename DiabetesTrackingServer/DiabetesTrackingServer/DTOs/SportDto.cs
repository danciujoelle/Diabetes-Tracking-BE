using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.DTOs
{
    public class SportDto
    {
        public float Duration { get; set; }
        public DateTime LoggedDate { get; set; }
        public string TypeOfActivity { get; set; }
        public string Notes { get; set; }
    }
}
