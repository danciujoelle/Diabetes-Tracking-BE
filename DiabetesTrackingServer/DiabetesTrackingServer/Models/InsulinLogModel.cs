using System;

namespace DiabetesTrackingServer.Models
{
    public class InsulinLogModel
    {
        public float InsulinIntake { get; set; }
        public string WhenWasInjected { get; set; }
        public string Notes { get; set; }
        public string UserId { get; set; }
    }
}
