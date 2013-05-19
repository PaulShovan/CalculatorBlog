using BlogProject.Models.Class;
using BlogProject.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Repositories
{
    public class PostRepository
    {
        private PostsDatabaseContext _context;

        public PostRepository()
        {
            _context = new PostsDatabaseContext();
        }

        /*public IEnumerable<Post> GetAllPosts()
        {
            
        }

        public IEnumerable<Post> GetAllRecentPosts()
        {

        }

        public Post GetFullPost(string postId)
        {
 
        }*/

        public List<Post> GetRecentPostTitle()
        {
            List<Post> PostTitle = _context.Posts.ToList();
            return PostTitle;
        }
    }
}