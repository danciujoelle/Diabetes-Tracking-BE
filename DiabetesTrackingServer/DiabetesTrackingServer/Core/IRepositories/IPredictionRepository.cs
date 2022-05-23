using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Core.IRepositories
{
    public interface IPredictionRepository
    {
        Task<IEnumerable<DiabetesPrediction>> GetAllPredictions();
        void InsertPrediction(PredictionModel predictionEntity, User user);
        Task<string> DoPredictionAsync(PredictionModel predictionEntity);
    }
}
