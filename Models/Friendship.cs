using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class Friendship
    {
        public int Id { get; set; }

        public ApplicationUser Sender { get; set; }

        public ApplicationUser Receiver { get; set; }

        public bool WaitingFlag { get; set; }

        public bool ApproveFlag { get; set; }
        
        public bool RejectFlag { get; set; }
        
        public bool BlockFlag { get; set; }
        
        public bool SpamFlag { get; set; }

        public DateTime DateCreated { get; set; }

        public List<Message> Messages { get; set; }

        public Friendship()
        {
            Messages = new List<Message>();
        }
    }
}