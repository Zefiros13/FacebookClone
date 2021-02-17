using FacebookClone.Interfaces;
using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Repositories
{
    public class PostRepository : IDisposable, IPostRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Post> GetAll()
        {
            return new List<Post>();
        }

        public IEnumerable<Post> GetByUserId(string usersId)
        {
            return new List<Post>();

        }

        public Post GetById(int id)
        {
            return new Post();
        }

        public void Create(Post post)
        {

        }

        public void Update(Post post)
        {

        }

        public void Delete(Post post)
        {

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