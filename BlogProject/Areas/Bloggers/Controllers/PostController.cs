using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject.Models.Class;
using BlogProject.Models.Db;

namespace BlogProject.Areas.Bloggers.Controllers
{
    public class PostController : Controller
    {
        private PostsDatabaseContext db = new PostsDatabaseContext();

        //
        // GET: /Bloggers/Post/

        public ActionResult Index()
        {
            var posts = db.Posts;
            return View(posts.ToList());
        }

        //
        // GET: /Bloggers/Post/Details/5

        public ActionResult Details(string id = null)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Bloggers/Post/Create

        public ActionResult Create()
        {
            ViewBag.PostedBy = new SelectList(db.Bloggers, "UserName", "FullName");
            return View();
        }

        //
        // POST: /Bloggers/Post/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.PostID = "Test03";
                post.PostedBy = "Test";
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostedBy = new SelectList(db.Bloggers, "UserName", "FullName", post.PostedBy);
            return View(post);
        }

        //
        // GET: /Bloggers/Post/Edit/5

        public ActionResult Edit(string id = null)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostedBy = new SelectList(db.Bloggers, "UserName", "FullName", post.PostedBy);
            return View(post);
        }

        //
        // POST: /Bloggers/Post/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostedBy = new SelectList(db.Bloggers, "UserName", "FullName", post.PostedBy);
            return View(post);
        }

        //
        // GET: /Bloggers/Post/Delete/5

        public ActionResult Delete(string id = null)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Bloggers/Post/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}