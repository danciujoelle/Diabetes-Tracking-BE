using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;

namespace DiabetesTrackingServer.Mappers
{
    public static class PredictionMapper
    {
        public static DiabetesPrediction MapToDataEntity(this PredictionModel prediction, User user)
        {
            return new DiabetesPrediction
            {
                PredictionId = new Guid(),
                Pregnancies = prediction.Pregnancies,
                PlasmaGlucose = prediction.PlasmaGlucose,
                DiastolicBloodPressure = prediction.DiastolicBloodPressure,
                TricepsThickness = prediction.TricepsThickness,
                SerumInsulin = prediction.SerumInsulin,
                BMI = prediction.BMI,
                DiabetesPedigree = prediction.DiabetesPredigree,
                Age = prediction.Age,
                Diabetic = prediction.Diabetic,
                User = user,
            };
        }
    }
}
