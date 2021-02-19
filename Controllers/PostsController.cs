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
    public class PostsController : ApiController
    {
        IPostRepository _repository { get; set; }

        public PostsController(IPostRepository repository)
        {
            _repository = repository;
        }

        //GET api/posts
        //Delete if not needed, because of route conflict or change route
        public IEnumerable<Post> GetAll()
        {
            return _repository.GetAll();
        }

        //GET api/posts
        public IEnumerable<Post> GetCurrentUsersFriendsPosts()
        {
            return _repository.GetCurrentUsersFriendsPosts();
        }

        //GET api/posts/?userId="str"
        public IEnumerable<Post> GetPostByUserId(string userId)
        {
            return _repository.GetByUserId(userId);
        }

        //GET api/posts/{id}
        public Post GetPostById(int id)
        {
            return _repository.GetById(id);
        }

        //POST api/posts
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(post);

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        //PUT api/posts/{id}
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(post);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(post);
        }

        //DELETE api/posts/{id}
        public IHttpActionResult DeletePost(int id)
        {
            var post = _repository.GetById(id);

            if (post == null)
            {
                return NotFound();
            }

            _repository.Delete(post);

            return Ok();
        }
    }
}
