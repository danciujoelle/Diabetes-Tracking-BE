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
    [Route("api/insulin")]
    [ApiController]
    public class InsulinController : ControllerBase
    {
        private IInsulinLogService _insulinLogService;
        private IUserService _userService;

        public InsulinController(IInsulinLogService insulinLogService, IUserService userService)
        {
            _insulinLogService = insulinLogService;
            _userService = userService;
        }

        [HttpGet]
        [Route("logs/{userId}")]
        public async Task<IActionResult> GetInsulinLogs(string userId)
        {
            var user = await _userService.GetUserById(Guid.Parse(userId));
            if (user != null)
            {
                var logs = await _insulinLogService.GetAllInsulinLogs(user);
                return Ok(logs);
            }
            return BadRequest(new
            {
                Message = "The input in not right",
            });
        }

        [HttpPost("log")]
        public async Task<IActionResult> InsertGlucoseLog([FromBody] InsulinLogModel insulinLog)
        {
            if (insulinLog == null)
            {
                return BadRequest();
            }
            else
            {
                var user = await _userService.GetUserById(Guid.Parse(insulinLog.UserId));
                if (user != null)
                {

                    var result = _insulinLogService.InsertLog(insulinLog, user);
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
