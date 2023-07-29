using System;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace UserManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            return await _userService.Register(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginDto loginDto)
        {
            return await _userService.Login(loginDto.Username, loginDto.Password);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetProfile(int id)
        {
            return await _userService.GetProfile(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateProfile(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            return await _userService.UpdateProfile(user);
        }
    }

}

