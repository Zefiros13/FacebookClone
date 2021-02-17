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

        [Required]
        public Friendship Friendship { get; set; }

        [Required]
        public ApplicationUser MessageSender { get; set; }

        [Required]
        public ApplicationUser MessageReceiver { get; set; }

        [Required]
        public string MessageContent { get; set; }

        public bool IsSeen { get; set; }
    }
}