using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetCurrentUsersFriendsPosts();
        IEnumerable<Post> GetByUserId(string usersId);
        Post GetById(int id);
        void Create(Post post);
        void Update(Post post);
        void Delete(Post post);
        string SavePost();
    }
}
