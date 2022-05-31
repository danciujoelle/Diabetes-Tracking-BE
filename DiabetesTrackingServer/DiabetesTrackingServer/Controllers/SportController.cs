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
    [Route("api/sport")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private ISportLogService _sportLogService;
        private IUserService _userService;

        public SportController(ISportLogService sportLogService, IUserService userService)
        {
            _sportLogService = sportLogService;
            _userService = userService;
        }

        [HttpGet]
        [Route("logs/{userId}")]
        public async Task<IActionResult> GetSportLogs(string userId)
        {
            var user = await _userService.GetUserById(Guid.Parse(userId));
            if (user != null)
            {
                var logs = await _sportLogService.GetAllSportLogs(user);
                return Ok(logs);
            }
            return BadRequest(new
            {
                Message = "The input in not right",
            });
        }

        [HttpPost("log")]
        public async Task<IActionResult> InsertSportLog([FromBody] SportLogModel sportLog)
        {
            if (sportLog == null)
            {
                return BadRequest();
            }
            else
            {
                var user = await _userService.GetUserById(Guid.Parse(sportLog.UserId));
                if (user != null)
                {

                    var result = _sportLogService.InsertLog(sportLog, user);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "The log was added successfully",
                        Output = ""
                    });
                }
                return BadRequest(new
                {
                    Message = "The input is not right",
                });
            }
        }
    }
}
