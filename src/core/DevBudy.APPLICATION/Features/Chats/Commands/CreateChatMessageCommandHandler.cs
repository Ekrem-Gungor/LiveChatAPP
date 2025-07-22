using DevBudy.APPLICATION.Events.ChatMessages;
using DevBudy.APPLICATION.Features.Chats.Dtos;
using DevBudy.CONTRACT.Repositories;
using DevBudy.DOMAIN.Entities.Concretes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Features.Chats.Commands
{
    public class CreateChatMessageCommandHandler : IRequestHandler<CreateChatMessageCommand, int>
    {
        private readonly IChatMessageRepository _chatMsgRepo;
        private readonly IMediator _mediator;

        public CreateChatMessageCommandHandler(IChatMessageRepository chatMsgRepo, IMediator mediator)
        {
            _chatMsgRepo = chatMsgRepo;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateChatMessageCommand request, CancellationToken cancellationToken)
        {
            ChatMessage chatMessage = new()
            {
                Message = request.Message,
                SenderID = request.SenderUserId,
            };
            await _chatMsgRepo.CreateAsync(chatMessage);

            ChatMessageDto chatMessageDto = new()
            {
                Id = chatMessage.ID,
                Message = chatMessage.Message,
                SenderUserId = chatMessage.SenderID,
                SenderUserName = chatMessage.Sender?.UserName ?? "Unknown User",
                SendAt = chatMessage.CreatedDate,
            };

            await _mediator.Publish(new ChatMessageCreatedEvent(chatMessageDto));
            return chatMessageDto.Id;
        }
    }
}
