using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Post Post { get; set; }

        public ApplicationUser CommentCreator { get; set; }
    }
}