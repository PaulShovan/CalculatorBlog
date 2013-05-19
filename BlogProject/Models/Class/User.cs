using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Class
{
    public class User
    {
        public UserLogin UserLogin { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public string Institute { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}