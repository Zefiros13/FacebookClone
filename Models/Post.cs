using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public ApplicationUser Creator { get; set; }

        public string Path { get; set; }

        public DateTime DateAdded { get; set; }

        public int LikeCount { get; set; }

        public bool IsLiked { get; set; }

        public bool IsDisliked { get; set; }

        public Post()
        {
            LikeCount = 0;
        }
    }
}