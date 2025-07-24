using DevBudy.APPLICATION.Features.AppUsers.Commands;
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

        public async Task SendMessage(string senderName, string message)
        {
            // Todo : En son burada kaldım.
            await _mediatR.Send(new CreateChatMessageCommand
            {
                SenderUserName = senderName,
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
        // Burada kaldım Authenticate olan kullanıcının ID sini alabilmek adına mecbur JWT kuracağım.
        public override async Task OnConnectedAsync()
        {
            await _mediatR.Send(new SetUserOnlineStatusCommand
            {
                UserId = Convert.ToInt32(Context.UserIdentifier),
                LastLogin = DateTime.Now,
                IsOnline = true
            });
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await _mediatR.Send(new SetUserOnlineStatusCommand
            {
                UserId = Convert.ToInt32(Context.UserIdentifier),
                LastLogout = DateTime.Now,
                IsOnline = false
            });
            await base.OnDisconnectedAsync(exception);
        }
    }
}
