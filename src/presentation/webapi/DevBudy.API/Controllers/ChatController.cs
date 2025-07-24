using DevBudy.APPLICATION.Features.Chats.Commands;
using DevBudy.APPLICATION.Features.Chats.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChatMessage(CreateChatMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("messages")]
        public async Task<IActionResult> GetAllChatMessages()
        {
            var result = await _mediator.Send(new GetAllChatMessagesQuery());
            return Ok(result);
        }
    }
}
