using DiabetesTrackingServer.Core.IRepositories;
using DiabetesTrackingServer.DataAccess;
using DiabetesTrackingServer.Mappers;
using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiabetesTrackingServer.MLmodels;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Text.Json;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;

namespace DiabetesTrackingServer.Core.Repositories
{
    public class PredictionRepository : IPredictionRepository
    {
        private DiabetesTrackingContext _dbContext;

        public PredictionRepository(DiabetesTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DiabetesPrediction>> GetAllPredictions()
        {
            return await _dbContext.Predictions.ToListAsync();
        }

        public string InsertPrediction(PredictionModel predictionEntity, User user)
        {

            var prediction = predictionEntity.MapToDataEntity(user);
            var result = _dbContext.Predictions.Add(prediction);
            _dbContext.SaveChanges();
            if (predictionEntity.Diabetic == 1)
            {
                return "You have been tested positive";
            } else
            {
                return "You have been tested negative";
            }
        }

        public async Task<PredictionModel> UsePredictionFastApiAsync(PredictionModel prediction)
        {
            var userPrediction = new Person(prediction.Pregnancies, prediction.PlasmaGlucose, prediction.DiastolicBloodPressure, prediction.TricepsThickness, prediction.SerumInsulin, prediction.BMI, prediction.DiabetesPredigree, prediction.Age);
            string url = "http://127.0.0.1:8000";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.PostAsJsonAsync("/predict", userPrediction);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var outcome = JsonConvert.DeserializeObject<Response>(result);
                    prediction.Diabetic = outcome.Outcome[0];
                    return prediction;
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return new PredictionModel();
                }
            }
        }
    }
}

