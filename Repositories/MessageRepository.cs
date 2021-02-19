using FacebookClone.Interfaces;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Repositories
{
    public class MessageRepository : IDisposable, IMessageRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Message> GetMessages(int friendshipId)
        {
            return _context.Messages.Where(m => m.Friendship.Id == friendshipId);
        }

        public Message GetById(int id)
        {
            return _context.Messages.SingleOrDefault(m => m.Id == id);
        }

        public void Create(Message message)
        {
            message.MessageSender = _context.Users.SingleOrDefault(u => u.Id == HttpContext.Current.User.Identity.GetUserId());
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void Delete(Message message)
        {
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}