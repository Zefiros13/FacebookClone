using FacebookClone.Helpers;
using FacebookClone.Interfaces;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Repositories
{
    public class FriendshipRepository : IDisposable, IFriendshipRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        string currentUsersId = HelperClass.GetCurrentUsersId();

        public IEnumerable<Friendship> GetUsersFriendships()
        {
            return _context.Friendships.Where(f => f.Sender.Id == currentUsersId 
                                                || f.Receiver.Id == currentUsersId);
        }

        public IEnumerable<Friendship> GetByUsersId(string id)
        {
            return _context.Friendships.Where(f => f.Sender.Id == id || f.Receiver.Id == id);
        }

        public Friendship GetById(int id)
        {
            return _context.Friendships.SingleOrDefault(f => f.Id == id);
        }

        public void Create(Friendship friendship)
        {
            friendship.Sender = HelperClass.GetCurrentUser();
            //TO DO
            //friendship.Receiver = Get user from current URL
            _context.Friendships.Add(friendship);
            _context.SaveChanges();
        }

        public void Delete(Friendship friendship)
        {
            _context.Friendships.Remove(friendship);
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