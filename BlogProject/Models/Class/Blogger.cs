using BlogProject.Areas.Bloggers.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Class
{
    /*Blogger class to represent information of a blogger*/
    public class Blogger
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string BloggerDetails { get; set; }
        public string Institute { get; set; }
        public string SpecialSector { get; set; }
        public ContactDetails Contact { get; set; } /*Navigation property*/
        public ICollection<Post> AllPosts { get; set; }/*Navigation Property to map foreign key*/
        public BloggerLogin BloggersLogin { get; set; }/*Navigation Property to map foreign key*/
    }
}