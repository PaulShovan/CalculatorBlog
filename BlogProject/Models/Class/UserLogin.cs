using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Class
{
    public class UserLogin
    {
        public User User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}