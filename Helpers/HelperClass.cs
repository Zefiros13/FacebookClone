using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Helpers
{
    public static class HelperClass
    {
        public static string GetCurrentUsersId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        public static ApplicationUser GetCurrentUser()
        {
            return new ApplicationDbContext().Users.SingleOrDefault(u => u.Id == GetCurrentUsersId());
        }


        //PostsController: Delete GetAll method if not needed because of route conflict or change route

        //TO IMPLEMENT
        //CommentRepository: comment.Post = GetCurrentPost?
        //FriendshipRepository: friendship.Receiver = Get user from current URL
        //MessageRepository: message.MessageReceiver = GetMessageReceiver?

        //Full change of model to add Collections (add List<Post> and List<Friendship> to ApplicationUser etc.) to allow Eager loading
    }
}