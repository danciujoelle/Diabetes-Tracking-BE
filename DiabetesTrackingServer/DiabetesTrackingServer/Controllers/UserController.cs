using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel user)
        {
            await _userService.UpdateUser(user);
            return Ok(new
            {
                StatusCode = 200,
                Message = "User Updated Successfully"
            });
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            _userService.DeleteUser(userId);
            return Ok();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                var isUsernameUnique = await _userService.IsUsernameUnique(user.Username);
                if (isUsernameUnique == true)
                {
                    await _userService.InsertUser(user);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "User Added Successfully"
                    });
                }
                return BadRequest(new
                {
                    Message = "Username Exists",
                });
            }
        }

        [HttpPost("login/{username}")]
        public async Task<IActionResult> Login(string username, [FromBody] string password)
        {
            if (username == null)
            {
                return BadRequest();
            }
            else
            {
                var existingUser = await _userService.GetUserByUsernameAndPassword(username, password);
                if (existingUser != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged in successfully",
                        UserData = existingUser
                    });
                }
            }
            return NotFound(new
            {
                StatusCode = 404,
                Message = "User not found"
            });
        }
    }
}
