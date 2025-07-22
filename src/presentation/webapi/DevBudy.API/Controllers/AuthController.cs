using DevBudy.APPLICATION.Features.Auths.Commands;
using DevBudy.APPLICATION.Features.Auths.Dtos.Request;
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
                LoginResponseDto result = await _mediatR.Send(requestCmd);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
