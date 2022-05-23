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
using System.Net.Http.Json;

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

        public void InsertPrediction(PredictionModel predictionEntity, User user)
        {

            var prediction = predictionEntity.MapToDataEntity(user);
            var result =  _dbContext.Predictions.Add(prediction);
            _dbContext.SaveChanges();
        }

        public async Task<string> DoPredictionAsync(PredictionModel predictionEntity)
        {
            string scoringUri = "https://ussouthcentral.services.azureml.net/workspaces/bbda1182141c4b35b6c9172f8a434148/services/e3bb70b92fdd4749b0181f8c51daac8b/execute?api-version=2.0&details=true";
            string authKey = "R3JUibi4aQOjZDcc5l4SVHMh64inCX4vsp4PZv4opoxUfLtGOHPlW8tZoSbe415PrDuEDZctbQMPJsAhC9jvuA==";

            var scoreRequest = new
            {

                Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"PatientID", "Pregnancies", "PlasmaGlucose", "DiastolicBloodPressure", "TricepsThickness", "SerumInsulin", "BMI", "DiabetesPedigree", "Age", "Diabetic"},
                                Values = new string[] {"0", predictionEntity.Pregnancies.ToString(), predictionEntity.PlasmaGlucose.ToString(), predictionEntity.DiastolicBloodPressure.ToString(), predictionEntity.TricepsThickness.ToString(), predictionEntity.SerumInsulin.ToString(), predictionEntity.BMI.ToString(), predictionEntity.DiabetesPredigree.ToString(), predictionEntity.Age.ToString(), predictionEntity.Diabetic.ToString()},
                            }
                    }, },
                GlobalParameters = new Dictionary<string, string>()
                {
                }
            };
            /*var payloadData = new PayloadData
            {
                Pregnancies = predictionEntity.Pregnancies,
                PlasmaGlucose = predictionEntity.PlasmaGlucose,
                DiastolicBloodPressure = predictionEntity.DiastolicBloodPressure,
                TricepsThickness = predictionEntity.TricepsThickness,
                SerumInsulin = predictionEntity.SerumInsulin,
                BMI = predictionEntity.BMI,
                DiabetesPedigree = predictionEntity.DiabetesPredigree,
                Age = predictionEntity.Age,
            };*/

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authKey);

            client.BaseAddress = new Uri(scoringUri);
            
            HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

            try
            {
               return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
