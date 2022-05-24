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

        public void InsertPrediction(PredictionModel predictionEntity, User user)
        {

            var prediction = predictionEntity.MapToDataEntity(user);
            var result =  _dbContext.Predictions.Add(prediction);
            _dbContext.SaveChanges();
        }

        public async Task<string> DoPredictionAsync(PredictionModel predictionEntity)
        {
            using (var client = new HttpClient())
            {
               //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] { "PatientID", "Pregnancies", "PlasmaGlucose", "DiastolicBloodPressure", "TricepsThickness", "SerumInsulin", "BMI", "DiabetesPedigree", "Age", "Diabetic" },
                                Values = new string[,] { { "0", predictionEntity.Pregnancies.ToString(), predictionEntity.PlasmaGlucose.ToString(), predictionEntity.DiastolicBloodPressure.ToString(), predictionEntity.TricepsThickness.ToString(), predictionEntity.SerumInsulin.ToString(), predictionEntity.BMI.ToString(), predictionEntity.DiabetesPredigree.ToString(), predictionEntity.Age.ToString(), predictionEntity.Diabetic.ToString() }, }
                            }
                        }, },
                    GlobalParameters = new Dictionary<string, string>() { }
                }; 
                const string scoringUri = "https://ussouthcentral.services.azureml.net/workspaces/bbda1182141c4b35b6c9172f8a434148/services/e3bb70b92fdd4749b0181f8c51daac8b/execute?api-version=2.0&details=true";
                const string authKey = "R3JUibi4aQOjZDcc5l4SVHMh64inCX4vsp4PZv4opoxUfLtGOHPlW8tZoSbe415PrDuEDZctbQMPJsAhC9jvuA==";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authKey);
                client.BaseAddress = new Uri(scoringUri);

                
                
                var content = new StringContent(JsonConvert.SerializeObject(scoreRequest).ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(scoringUri, content).Result;
                //HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
            };

            }
        }
    }

