using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.Models.DB
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<NewPost> NewPosts { get; set; }
        public ICollection<LikePost> LikePosts { get; set; }
    }
}
