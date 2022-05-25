using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Models
{
    public class Person
    {
        public int pregnancies { get; set; }
        public int glucose { get; set; }
        public int bp { get; set; }
        public int skinthickness { get; set; }
        public int insulin { get; set; }
        public float bmi { get; set; }
        public float dpf { get; set; }
        public int age { get; set; }

        public Person(int pregnancies, int plasmaGlucose, int diastolicBloodPressure, int tricepsThickness, int serumInsulin, float BMI, float diabetesPredigree, int age)
        {
            this.pregnancies = pregnancies;
            this.glucose = plasmaGlucose;
            this.bp = diastolicBloodPressure;
            this.skinthickness = tricepsThickness;
            this.insulin = serumInsulin;
            this.bmi = BMI;
            this.dpf = diabetesPredigree;
            this.age = age;
        }

    }
}
