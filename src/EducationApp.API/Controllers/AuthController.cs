﻿using EducationApp.Application.Models;
using EducationApp.Application.Models.Dtos;
using EducationApp.Application.Service.IAuthServices;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ApiResult<string>> RegisterAsync([FromBody] RegisterRequestDto register)
        {
            var result = await authService
                .RegisterAsync(register);
            return result;
        }

        [HttpPost("login")]
        public async Task<ApiResult<LoginResponseDto>> LoginAsync([FromBody] LoginRequestDto login)
        {
            var result = await authService.LoginAsync(login);
            return result;
        }
    }
}
