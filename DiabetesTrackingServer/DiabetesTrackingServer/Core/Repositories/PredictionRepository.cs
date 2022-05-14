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
using Newtonsoft.Json;

namespace DiabetesTrackingServer.Core.Repositories
{
    public class PredictionRepository : IPredictionRepository
    {
        private DiabetesTrackingContext _dbContext;

        public async Task<IEnumerable<DiabetesPrediction>> GetAllPredictions()
        {
            return await _dbContext.Predictions.ToListAsync();
        }

        public void InsertPrediction(PredictionModel predictionEntity, User user)
        {

            var prediction = predictionEntity.MapToDataEntity(user);
            var result =  _dbContext.Predictions.Add(prediction);
            _dbContext.SaveChanges();
        }

        public string DoPrediction(PredictionModel predictionEntity)
        {
            string scoringUri = "https://studio.azureml.net/Home/ViewWorkspaceCached/bbda1182141c4b35b6c9172f8a434148?#Workspaces/WebServiceGroups/WebServiceGroup/7d494dca632f4ee3a5498b087746fb04/dashboard";
            string authKey = "R3JUibi4aQOjZDcc5l4SVHMh64inCX4vsp4PZv4opoxUfLtGOHPlW8tZoSbe415PrDuEDZctbQMPJsAhC9jvuA==";

            var payloadData = new PayloadData
            {
                Pregnancies = predictionEntity.Pregnancies,
                PlasmaGlucose = predictionEntity.PlasmaGlucose,
                DiastolicBloodPressure = predictionEntity.DiastolicBloodPressure,
                TricepsThickness = predictionEntity.TricepsThickness,
                SerumInsulin = predictionEntity.SerumInsulin,
                BMI = predictionEntity.BMI,
                DiabetesPedigree = predictionEntity.DiabetesPredigree,
                Age = predictionEntity.Age,
            };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authKey);

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(scoringUri));
                request.Content = new StringContent(JsonConvert.SerializeObject(payloadData));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.SendAsync(request).Result;
                //display the response from the web service
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
