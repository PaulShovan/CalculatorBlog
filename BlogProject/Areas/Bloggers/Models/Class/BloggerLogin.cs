using BlogProject.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.Areas.Bloggers.Models.Class
{
    public class BloggerLogin
    {
        public string BloggerUserId { get; set; }
        public string BPassword { get; set; }
        public Blogger Blogger { get; set; }
    }
}