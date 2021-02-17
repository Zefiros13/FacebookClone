using FacebookClone.Interfaces;
using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FacebookClone.Controllers
{
    public class UsersController : ApiController
    {
        IUserRepository _repository { get; set; }

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        //GET api/users/?username="str"
        public IEnumerable<ApplicationUser> GetUsersByUsername(string username)
        {
            return _repository.GetByUsername(username);
        }

        //GET api/users/{id}
        public ApplicationUser GetUserById(string id)
        {
            return _repository.GetById(id);
        }

        //PUT api/users/{id}
        public IHttpActionResult PutUser(string id, ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(user);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(user);
        }

        //DELETE api/users/{id}
        public IHttpActionResult Deleteuser(string id)
        {
            var user = _repository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _repository.Delete(user);

            return Ok();
        }
    }
}
