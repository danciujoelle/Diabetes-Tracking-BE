using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Controllers
{
    [Route("api/predictions")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private IPredictionService _predictionService;
        private IUserService _userService;

        public PredictionController(IPredictionService predictionService, IUserService userService)
        {
            _predictionService = predictionService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPredictions()
        {
            var predictions = await _predictionService.GetAllPredictions();
            return Ok(predictions);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertPrediction([FromBody] PredictionModel prediction)
        {
            if (prediction == null)
            {
                return BadRequest();
            }
            else
            {
                var user = await _userService.GetUserById(Guid.Parse(prediction.UserId));
                if (user != null)
                {

                    var result = _predictionService.InsertPrediction(prediction, user);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = result,
                        Output = ""
                    });
                }
                return BadRequest(new
                {
                    Message = "The input in not right",
                });
            }
        }
    }
}
