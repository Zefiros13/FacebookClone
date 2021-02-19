using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        Comment GetById(int id);
        void Create(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}
