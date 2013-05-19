using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Models.Class
{
    public class Post
    {
        [HiddenInput(DisplayValue=false)]
        public string PostID { get; internal set; }
        public string PostTitle { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime PostDate { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string PostedBy { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string Tag { get; set; }
        public string PostSummary { get; set; }
        public int UsefulRate { get; set; }
        public Blogger Blogger { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}