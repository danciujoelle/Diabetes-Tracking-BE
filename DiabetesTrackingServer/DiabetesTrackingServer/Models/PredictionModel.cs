
namespace DiabetesTrackingServer.Models
{
    public class PredictionModel
    {
        public string PredictionId { get; set; }
        public int Pregnancies { get; set; }
        public int PlasmaGlucose { get; set; }
        public int DiastolicBloodPressure { get; set; }
        public int TricepsThickness { get; set; }
        public int SerumInsulin { get; set; }
        public double BMI { get; set; }
        public double DiabetesPredigree { get; set; }
        public int Age { get; set; }
        public int Diabetic { get; set; }
        public string UserId { get; set; }
    }
}
