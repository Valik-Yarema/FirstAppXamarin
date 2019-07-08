using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.Models.DB
{
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public NewPost NewPost { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string TextComment { get; set; }
    }
}
