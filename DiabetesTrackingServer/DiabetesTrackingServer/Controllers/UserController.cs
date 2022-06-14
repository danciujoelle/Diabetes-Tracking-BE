using DiabetesTrackingServer.DTOs;
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


        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel user)
        {
            if (user != null)
            {
                var existingUser = await _userService.GetUserById(user.UserId);
                var isUsernameUnique = await _userService.IsUsernameUnique(user.Username);
                var isEmailUnique = await _userService.IsEmailUnique(user.Email);
                if ((isUsernameUnique == true || user.Username == existingUser.Username) && (isEmailUnique == true || user.Email == existingUser.Email))
                {
                    await _userService.UpdateUser(user);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "User Updated Successfully"
                    });
                }
                if (isUsernameUnique == false)
                {
                    return BadRequest(new
                    {
                        Message = "An account using this username already exists",
                    });
                }
                return BadRequest(new
                {
                    Message = "An account using this email already exists.",
                });
            } else
            {
                return BadRequest(new
                {
                    Message = "The user does not exist",
                });
            }
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
                var isEmailUnique = await _userService.IsEmailUnique(user.Email);
                if (isUsernameUnique == true && isEmailUnique == true)
                {
                    await _userService.InsertUser(user);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "User Added Successfully"
                    });
                }
                if(isUsernameUnique == false)
                {
                    return BadRequest(new
                    {
                        Message = "An account using this username already exists",
                    });
                }
                return BadRequest(new
                {
                    Message = "An account using this email already exists.",
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
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "The username or password are incorrect"
                    });
                }
            }
            return NotFound(new
            {
                StatusCode = 404,
                Message = "The username or password are incorrect"
            });
        }

        [HttpPost("update/password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequestDto updatePasswordRequestBody)
        {
            if(updatePasswordRequestBody.UserId == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "The userId is incorrect"
                });
            }
            await _userService.UpdatePassword(updatePasswordRequestBody.UserId, updatePasswordRequestBody.NewPassword);
            return Ok(new
            {
                StatusCode = 200,
                Message = "The Password Was Updated Successfully"
            });
        }
    }
}
