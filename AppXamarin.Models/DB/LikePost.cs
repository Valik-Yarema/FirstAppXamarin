using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.Models.DB
{
    public class LikePost
    {
        public int UserId { get; set; }
        public ApplicationUser  ApplicationUser{get;set;}

        public int NewPostId { get; set; }

        public NewPost NewPost { get; set; }
    }
}
