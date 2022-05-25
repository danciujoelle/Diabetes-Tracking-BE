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

        public async Task<string> InsertPrediction(PredictionModel predictionEntity, User user)
        {
            var resultedPrediction = await _predictionRepository.UsePredictionFastApiAsync(predictionEntity);
            return _predictionRepository.InsertPrediction(resultedPrediction, user);
            //return _predictionRepository.DoPredictionAsync(predictionEntity);
        }
    }
}