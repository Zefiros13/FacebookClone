using FacebookClone.Interfaces;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace FacebookClone.Repositories
{
    public class PostRepository : IDisposable, IPostRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        public IEnumerable<Post> GetByUserId(string usersId)
        {
            return _context.Posts.Where(p => p.Creator.Id == usersId) ;
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public void Create(Post post)
        {
            post.Creator = _context.Users.SingleOrDefault(u => u.Id == HttpContext.Current.User.Identity.GetUserId());
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
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