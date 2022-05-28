using System;

namespace DiabetesTrackingServer.Models
{
    public class SportLogModel
    {
        public float Duration { get; set; }
        public string TypeOfActivity { get; set; }
        public string Notes { get; set; }
        public string UserId { get; set; }
    }
}
