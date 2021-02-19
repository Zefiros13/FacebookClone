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
    [Authorize]
    public class CommentsController : ApiController
    {
        ICommentRepository _repository { get; set; }

        public CommentsController(ICommentRepository repository)
        {
            _repository = repository;
        }

        //GET api/comments/?postId="int"
        [AllowAnonymous] //Maybe bad idea,depends on Post privacy
        public IEnumerable<Comment> GetByPostId(int postId)
        {
            return _repository.GetCommentsByPostId(postId);
        }

        //GET api/comments/{id}
        public Comment GetById(int id)
        {
            return _repository.GetById(id);
        }

        //POST api/comments
        public IHttpActionResult PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(comment);

            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        //PUT api/comments/{id}
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(comment);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(comment);
        }

        //DELETE api/comments/{id}
        public IHttpActionResult DeleteComment(int id)
        {
            var comment = _repository.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            _repository.Delete(comment);

            return Ok();
        }

    }
}
