using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetByUsername(string username);
        ApplicationUser GetById(string id);
        void Update(ApplicationUser user);
        void Delete(ApplicationUser user);
    }
}
