using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.Interfaces
{
    public interface IFriendshipRepository
    {
        IEnumerable<Friendship> GetUsersFriendships();
        IEnumerable<Friendship> GetByUsersId(string id);
        Friendship GetById(int id);
        void Create(Friendship friendship);
        void Delete(Friendship friendship);
    }
}
