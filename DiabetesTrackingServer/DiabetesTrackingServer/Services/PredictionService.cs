using DiabetesTrackingServer.Core.IRepositories;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public class PredictionService : IPredictionService
    {
        private IPredictionRepository _predictionRepository;
        public PredictionService(IPredictionRepository predictionRepository)
        {
            _predictionRepository = predictionRepository;
        }
        public async Task<IEnumerable<DiabetesPrediction>> GetAllPredictions()
        {
            return await _predictionRepository.GetAllPredictions();
        }

        public Task<string> InsertPrediction(PredictionModel predictionEntity, User user)
        {
            _predictionRepository.InsertPrediction(predictionEntity, user);
            return _predictionRepository.DoPredictionAsync(predictionEntity);
        }
    }
}