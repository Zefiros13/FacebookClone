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
    public class FriendshipsController : ApiController
    {
        public IFriendshipRepository _repository { get; set; }

        public FriendshipsController(IFriendshipRepository repository)
        {
            _repository = repository;
        }

        //GET api/friendships
        public IEnumerable<Friendship> GetUsersFriendships()
        {
            return _repository.GetUsersFriendships();
        }

        //GET api/friendships/?usersId="str"
        public IEnumerable<Friendship> GetByUsersId(string id)
        {
            return _repository.GetByUsersId(id);
        }

        //GET api/friendships/{id}
        public Friendship GetById(int id)
        {
            return _repository.GetById(id);
        }

        //POST api/friendships
        public IHttpActionResult PostFriendship(Friendship friendship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(friendship);

            return CreatedAtRoute("DefaultApi", new { id = friendship.Id }, friendship);
        }

        //DELETE api/friendships/{id}
        public IHttpActionResult DeleteFriendship(int id)
        {
            Friendship friendship = _repository.GetById(id);

            if (friendship == null)
            {
                return NotFound();
            }

            _repository.Delete(friendship);

            return Ok();
        }
    }
}
