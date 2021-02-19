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
    public class CommentRepository : IDisposable, ICommentRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Comment> GetCommentsByPostId(int postId)
        {
            return _context.Comments.Where(c => c.Post.Id == postId);
        }

        public Comment GetById(int id)
        {
            return _context.Comments.SingleOrDefault(c => c.Id == id);
        }

        public void Create(Comment comment)
        {
            comment.CommentCreator = _context.Users.SingleOrDefault(u => u.Id == HttpContext.Current.User.Identity.GetUserId());
            //TO DO
            //comment.Post = GetCurrentPost?
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
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