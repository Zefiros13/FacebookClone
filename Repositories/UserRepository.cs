using FacebookClone.Interfaces;
using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace FacebookClone.Repositories
{
    public class UserRepository : IDisposable, IUserRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<ApplicationUser> GetByUsername(string username)
        {
            return _context.Users.Where(u => u.UserName == username);
        }

        public ApplicationUser GetById(string id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public void Update(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(ApplicationUser user)
        {
            _context.Users.Remove(user);
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