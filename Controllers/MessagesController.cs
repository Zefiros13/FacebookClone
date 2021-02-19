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
    public class MessagesController : ApiController
    {
        IMessageRepository _repository { get; set; }

        public MessagesController(IMessageRepository repository)
        {
            _repository = repository;
        }

        //GET api/messages/friendsipId="int"
        public IEnumerable<Message> GetMessages(int friendshipId)
        {
            return _repository.GetMessages(friendshipId);
        }

        //POST api/messages
        public IHttpActionResult PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(message);

            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }

        //DELETE api/messages/{id}
        public IHttpActionResult DeleteMessage(int id)
        {
            var message = _repository.GetById(id);

            if (message == null)
            {
                return NotFound();
            }

            _repository.Delete(message);

            return Ok();
        }
    }
}
