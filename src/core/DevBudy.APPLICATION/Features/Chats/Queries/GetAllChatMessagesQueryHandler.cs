using DevBudy.APPLICATION.Features.Chats.Dtos;
using DevBudy.CONTRACT.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Features.Chats.Queries
{
    public class GetAllChatMessagesQueryHandler : IRequestHandler<GetAllChatMessagesQuery, List<ChatMessageDto>>
    {
        readonly IChatMessageRepository _chatMsgRepo;

        public GetAllChatMessagesQueryHandler(IChatMessageRepository chatMsgRepo)
        {
            _chatMsgRepo = chatMsgRepo;
        }

        public async Task<List<ChatMessageDto>> Handle(GetAllChatMessagesQuery request, CancellationToken cancellationToken)
        {
            List<ChatMessageDto> chatMessages = _chatMsgRepo.GetAllAsync().Result
                .Select(msg => new ChatMessageDto
                {
                    Id = msg.ID,
                    Message = msg.Message,
                    SendAt = msg.CreatedDate,
                    SenderUserId = msg.SenderID,
                    SenderUserName = msg.Sender.UserName
                }).ToList();
            return chatMessages;
        }
    }
}
