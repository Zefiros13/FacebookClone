using FacebookClone.Helpers;
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
    public class PostRepository : IDisposable, IPostRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        string currentUsersId = HelperClass.GetCurrentUsersId();

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        public IEnumerable<Post> GetCurrentUsersFriendsPosts()
        {
            List<Post> allFriendsPosts = new List<Post>();
            List<Friendship> currentUsersFriendships = _context.Friendships.Where(f => f.Sender.Id == currentUsersId 
                                                                                    || f.Receiver.Id == currentUsersId).ToList();
            
            foreach (Friendship friendship in currentUsersFriendships)
            {
                var posts = _context.Posts.Where(p => p.Creator.Id == friendship.Sender.Id 
                                                   || p.Creator.Id == friendship.Receiver.Id);
                foreach (Post post in posts)
                {
                    allFriendsPosts.Add(post);
                } 
            }

            return allFriendsPosts;
        }

        public IEnumerable<Post> GetByUserId(string usersId)
        {
            return _context.Posts.Where(p => p.Creator.Id == usersId);
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public void Create(Post post)
        {
            post.Creator = HelperClass.GetCurrentUser();
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

        public string SavePost()
        {
            try
            {
                HttpRequest httpRequest = HttpContext.Current.Request;
                var post = httpRequest.Files[0]; // Uploading only first picture in case multiple pictures are selected
                string postName = post.FileName;
                string physicalPath = HttpContext.Current.Server.MapPath("~/Media/Photos/" + postName);

                post.SaveAs(physicalPath);

                return postName;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
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