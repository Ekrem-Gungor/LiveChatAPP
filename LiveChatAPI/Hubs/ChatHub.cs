using LiveChatAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace LiveChatAPI.Hubs
{
    public class ChatHub : Hub
    {
        static readonly List<ChatMessage> _messages = new();
        static readonly Dictionary<string, string> UserConnections = new();
        public async Task SendMessage(string user, string message)
        {
            ChatMessage msg = new()
            {
                User = user,
                Message = message
            };
            _messages.Add(msg);

            await Clients.All.SendAsync("ReceiveMessage", msg);
        }

        public List<ChatMessage> GetMessages()
        {
            return _messages;
        }

        public async Task Join(string user)
        {
            UserConnections[Context.ConnectionId] = user;

            await Clients.All.SendAsync("ReceiveMessage", new ChatMessage
            {
                User = "SYSTEM",
                Message = $"{user} joined the chat"
            });
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string connectionId = Context.ConnectionId;

            if (UserConnections.TryGetValue(connectionId, out string? user))
            {
                await Clients.All.SendAsync("ReciveMessage", new ChatMessage
                {
                    User = "SYSTEM",
                    Message = $"{user} left the chat"
                });

                UserConnections.Remove(connectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
