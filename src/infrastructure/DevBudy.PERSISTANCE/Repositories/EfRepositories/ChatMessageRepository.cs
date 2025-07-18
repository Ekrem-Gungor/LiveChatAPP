using DevBudy.CONTRACT.Repositories;
using DevBudy.DOMAIN.Entities.Concretes;
using DevBudy.PERSISTANCE.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.PERSISTANCE.Repositories.EfRepositories
{
    public class ChatMessageRepository : Repository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(DevBudyContext db) : base(db)
        {

        }
    }
}
