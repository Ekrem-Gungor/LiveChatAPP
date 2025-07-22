using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Features.Chats.Dtos
{
    public class SystemMessageDto : BaseDto
    {
        public SystemMessageDto()
        {
            SenderName = "System";
            SystemMessage = ", Sohbete katıldı.";
        }
        public string SenderName { get; }
        public string SystemMessage { get; }
        public string JoinedUserName { get; set; }
    }
}
