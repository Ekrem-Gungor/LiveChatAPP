using DevBudy.APPLICATION.Events.ChatMessages;
using DevBudy.APPLICATION.Features.Chats.Dtos;
using DevBudy.CONTRACT.Repositories;
using DevBudy.DOMAIN.Entities.Concretes;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IMediator _mediator;

        public CreateChatMessageCommandHandler(IChatMessageRepository chatMsgRepo, IMediator mediator, UserManager<AppUser> userManager)
        {
            _chatMsgRepo = chatMsgRepo;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateChatMessageCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Message) || string.IsNullOrEmpty(request.SenderUserName))
            {
                throw new ArgumentException("Message cannot be empty.", nameof(request.Message));
            }
            int senderUserId = _userManager.FindByNameAsync(request.SenderUserName).Result.Id;
            ChatMessage chatMessage = new()
            {
                SenderID = senderUserId,
                Message = request.Message
            };
            await _chatMsgRepo.CreateAsync(chatMessage);

            ChatMessageDto chatMessageDto = new()
            {
                Id = chatMessage.ID,
                Message = chatMessage.Message,
                SenderUserId = chatMessage.SenderID,
                SenderUserName = chatMessage.Sender?.UserName ?? "Unknown User",
                SendAt = chatMessage.CreatedDate
            };

            await _mediator.Publish(new ChatMessageCreatedEvent(chatMessageDto));
            return chatMessageDto.Id;
        }
    }
}
