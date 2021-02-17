using System;
using System.Collections.Generic;
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

        public string MessageContent { get; set; }

        public bool IsSeen { get; set; }
    }
}