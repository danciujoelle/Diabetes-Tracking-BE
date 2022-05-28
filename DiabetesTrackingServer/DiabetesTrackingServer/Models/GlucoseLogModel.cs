
namespace DiabetesTrackingServer.Models
{
    public class GlucoseLogModel
    {
        public float GlucoseLevel { get; set; }
        public string WhenWasLogged { get; set; }
        public string Notes { get; set; }
        public string UserId { get; set; }
    }
}
