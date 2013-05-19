using BlogProject.Areas.Bloggers.Models.Class;
using BlogProject.Models.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Db
{
    public class PostsDatabaseContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Blogger> Bloggers { get; set; }
        public DbSet<ContactDetails> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new BloggerConfiguration());
            modelBuilder.Configurations.Add(new ContactDetailsConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserLoginConfiguration());
            modelBuilder.Configurations.Add(new BloggerLoginConfiguration());
        }
    }
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(post => post.PostTitle).IsRequired().HasMaxLength(100);
            Property(post => post.PostDate).IsRequired();
            HasKey(post => post.PostID);
            Property(post => post.Body).IsRequired().IsMaxLength();
            Property(post => post.PostSummary).IsRequired();
            HasRequired(post => post.Blogger).WithMany(b => b.AllPosts).HasForeignKey(post => post.PostedBy);
            Property(post => post.Tag).IsRequired();
            Property(post => post.UsefulRate).IsOptional();
            
        }
    }
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasRequired(cmnt => cmnt.Post).WithMany(c => c.Comments).HasForeignKey(cmnt => cmnt.PostID);
            HasRequired(user => user.User).WithMany(cmnt => cmnt.Comments).HasForeignKey(cmnt => cmnt.CommentBy);
            HasKey(cmnt => cmnt.CommentID);
            Property(cmnt => cmnt.CommentBody).IsRequired();
            Property(cmnt => cmnt.CommentDate).IsRequired();
        }
    }
    public class ContactDetailsConfiguration : EntityTypeConfiguration<ContactDetails>
    {
        public ContactDetailsConfiguration()
        {
            HasKey(cdel => cdel.UserName);
            HasRequired(cdel => cdel.aBlogger).WithRequiredPrincipal(a => a.Contact);
            Property(cdet => cdet.Email).IsRequired();
        }
    }
    public class BloggerConfiguration : EntityTypeConfiguration<Blogger>
    {
        public BloggerConfiguration()
        {
            HasKey(blogger => blogger.UserName);
            Property(blogger => blogger.FullName).IsRequired();
            Property(blogger => blogger.BloggerDetails).IsRequired();
            Property(blogger => blogger.Institute).HasMaxLength(200);
            Property(blogger => blogger.SpecialSector).HasMaxLength(200);
        }
    }
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(user => user.UserName);
            Property(user => user.Email).IsRequired().HasMaxLength(100);
            Property(user => user.FullName).IsRequired().HasMaxLength(100);
            Property(user => user.JoinDate).IsRequired();
        }
    }
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            HasKey(ulogin => ulogin.UserName);
            HasRequired(ulogin => ulogin.User).WithRequiredPrincipal(a => a.UserLogin);
            Property(ulogin => ulogin.Password).IsRequired();
        }
    }
    public class BloggerLoginConfiguration : EntityTypeConfiguration<BloggerLogin>
    {
        public BloggerLoginConfiguration()
        {
            HasKey(blogin => blogin.BloggerUserId);
            HasRequired(blogin => blogin.Blogger).WithRequiredPrincipal(a => a.BloggersLogin);
            Property(ulogin => ulogin.BPassword).IsRequired();
        }
    }

}