using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Class
{
    public class ContactDetails
    {
        public Blogger aBlogger { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FacebookContact { get; set; }
        public string TwitterContact { get; set; }
    }
}