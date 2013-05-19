using BlogProject.Models.Class;
using BlogProject.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Areas.Bloggers.Models.Repositories
{
    public class PostCreateRepository
    {
        private PostsDatabaseContext _context;

        public PostCreateRepository()
        {
            _context = new PostsDatabaseContext();
        }

        public void CreatePost(Post aPost)
        {
            int totalPost = 0;
            try
            {
                totalPost = _context.Posts.Count();
                aPost.PostID = aPost.Tag + totalPost.ToString();
                if (aPost.PostID != null)
                {
                    _context.Posts.Add(aPost);
                    _context.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                throw new Exception("Error during creating post"+exp);
            }
        }
    }
}