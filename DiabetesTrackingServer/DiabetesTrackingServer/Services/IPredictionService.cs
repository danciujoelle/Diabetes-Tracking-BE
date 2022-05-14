using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public interface IPredictionService
    {
        Task<IEnumerable<DiabetesPrediction>> GetAllPredictions();
        string InsertPrediction(PredictionModel predictionEntity, User user);
    }
}
