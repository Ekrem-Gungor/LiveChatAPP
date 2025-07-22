using DevBudy.APPLICATION.Features.Chats.Commands;
using DevBudy.DOMAIN.Entities.Concretes;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace DevBudy.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediatR;
        public ChatHub(IMediator mediator)
        {
            _mediatR = mediator;
        }

        public async Task SendMessage(int senderId, string message)
        {
            // Todo : En son burada kaldım.
            await _mediatR.Send(new CreateChatMessageCommand
            {
                SenderUserId = senderId,
                Message = message
            });
        }

        public async Task Join(string joinedName)
        {
            await _mediatR.Send(new CreateSystemMessageCommand
            {
                JoinedUserName = joinedName
            });
        }
    }
}
