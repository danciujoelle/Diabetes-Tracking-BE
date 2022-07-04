using System;
using System.ComponentModel.DataAnnotations;

namespace DiabetesTrackingServer.ViewModels
{
    public class DiabetesPrediction
    {
        [Key, Required]
        public Guid PredictionId { get; set; }

        [Required]
        public int Pregnancies { get; set; }

        [Required]
        public int PlasmaGlucose { get; set; }

        [Required]
        public int DiastolicBloodPressure { get; set; }

        [Required]
        public int TricepsThickness { get; set; }

        [Required]
        public int SerumInsulin { get; set; }

        [Required]
        public float BMI { get; set; }

        [Required]
        public float DiabetesPedigree { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        public int Diabetic { get; set; }

        public User User { get; set; }
    }
}

