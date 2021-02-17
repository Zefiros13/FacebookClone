using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class Message
    {
        public int Id { get; set; }

        public Friendship Friendship { get; set; }

        public ApplicationUser MessageSender { get; set; }

        public ApplicationUser MessageReceiver { get; set; }

        [Required]
        public string MessageContent { get; set; }

        public bool IsSeen { get; set; }
    }
}