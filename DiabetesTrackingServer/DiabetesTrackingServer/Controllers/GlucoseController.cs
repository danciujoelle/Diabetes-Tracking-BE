using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Controllers
{
    [Route("api/glucose")]
    [ApiController]
    public class GlucoseController : ControllerBase
    {
        private IGlucoseLogService _glucoseLogService;
        private IUserService _userService;

        public GlucoseController(IGlucoseLogService glucoseLogService, IUserService userService)
        {
            _glucoseLogService = glucoseLogService;
            _userService = userService;
        }

        [HttpGet]
        [Route("logs/{userId}")]
        public async Task<IActionResult> GetGlucoseLogs(string userId)
        {
            var user = await _userService.GetUserById(Guid.Parse(userId));
            if (user != null)
            {
                var logs = await _glucoseLogService.GetAllGlucoseLogs(user);
                return Ok(logs);
            }
            return BadRequest(new
            {
                Message = "The input in not right",
            });
        }

        [HttpPost("log")]
        public async Task<IActionResult> InsertGlucoseLog([FromBody] GlucoseLogModel glucoseLog)
        {
            if (glucoseLog == null)
            {
                return BadRequest();
            }
            else
            {
                var user = await _userService.GetUserById(Guid.Parse(glucoseLog.UserId));
                if (user != null)
                {

                    var result = _glucoseLogService.InsertLog(glucoseLog, user);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "The log was added successfully",
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
