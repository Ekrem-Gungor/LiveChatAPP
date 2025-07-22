using DevBudy.APPLICATION.Features.Chats.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Features.Chats.Queries
{
    public class GetAllChatMessagesQuery : IRequest<List<ChatMessageDto>>
    {

    }
}
