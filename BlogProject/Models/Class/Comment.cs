using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Class
{
    public class Comment
    {
        public string PostID { get; set; }
        public string CommentBy { get; set; }
        public string CommentID { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDate { get; set; }
        public Post Post { get; set; }//Navigation property
        public User User { get; set; }//Navigation property      
    }
}