using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventService _eventService;
        private IUserService _userService;

        public EventController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetEvents(string userId)
        {
            var user = await _userService.GetUserById(Guid.Parse(userId));
            if (user != null)
            {

                var events = await _eventService.GetAllEvents(user);
                return Ok(events);
            }
            return BadRequest(new
            {
                Message = "The input in not right",
            });
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertEvent([FromBody] EventModel appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }
            else
            {
                var user = await _userService.GetUserById(Guid.Parse(appointment.UserId));
                if (user != null)
                {

                    var result = _eventService.InsertEvent(appointment, user);
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
