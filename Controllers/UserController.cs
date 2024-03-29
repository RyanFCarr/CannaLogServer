﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper) {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(UserSaveDto user) 
        {
            var userModel = _mapper.Map<User>(user);
            userModel.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var newUser = _userService.Create(userModel);

            return new OkObjectResult(_mapper.Map<UserDto>(newUser));
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password) 
        {
            var user = _userService.GetOne(email);

            if (user == null)  return BadRequest("Incorrect Credentials");

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) return BadRequest("Incorrect Credentials");

            var userDto = _mapper.Map<UserDto>(user);

            userDto.Token = _userService.GenerateToken(user);

            return Ok(userDto);

        }
    }

}
