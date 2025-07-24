﻿using DevBudy.APPLICATION.Features.Auths.Commands;
using DevBudy.APPLICATION.Features.Auths.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public AuthController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUserCommand requestCmd)
        {
            try
            {
                LoginResponseDto loginResult = await _mediatR.Send(requestCmd);
                TokenResponseDto jwtResult = await _mediatR.Send(new GenerateTokenCommand() { UserId = loginResult.UserId });
                return Ok(jwtResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
