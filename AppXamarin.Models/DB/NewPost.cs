using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppXamarin.Models.DB
{
   public class NewPost
    {
        //public Guid Id { get; set; } = Guid.NewGuid();
        public int Id { get; set; }
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
        public string AuthorName { get; set; }
        public string NewsText { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<Comment> Comments { get; set; }
        public ICollection<LikePost> LikePosts { get; set; }
        //public ICollection<Image> Images { get; set; }
        public ImageSource PostSource { get; set; }
        public int Like { get; set; }
       
    }
}
