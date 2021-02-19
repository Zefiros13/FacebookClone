using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetMessages(int friendshipId);
        Message GetById(int id);
        void Create(Message message);
        void Delete(Message message);
    }
}
