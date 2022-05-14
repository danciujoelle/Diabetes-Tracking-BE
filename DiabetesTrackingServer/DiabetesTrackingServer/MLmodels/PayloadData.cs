using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.MLmodels
{
    public class PayloadData
    {
        public int Pregnancies { get; set; }
        public int PlasmaGlucose { get; set; }
        public int DiastolicBloodPressure { get; set; }
        public int TricepsThickness { get; set; }
        public int SerumInsulin { get; set; }
        public double BMI { get; set; }
        public double DiabetesPedigree { get; set; }
        public int Age { get; set; }
    }
}
