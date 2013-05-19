namespace BlogProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.String(nullable: false, maxLength: 128),
                        PostTitle = c.String(nullable: false, maxLength: 100),
                        PostDate = c.DateTime(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 128),
                        Body = c.String(nullable: false),
                        Tag = c.String(nullable: false),
                        PostSummary = c.String(nullable: false),
                        UsefulRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Bloggers", t => t.PostedBy, cascadeDelete: true)
                .Index(t => t.PostedBy);
            
            CreateTable(
                "dbo.Bloggers",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        BloggerDetails = c.String(nullable: false),
                        Institute = c.String(maxLength: 200),
                        SpecialSector = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.UserName)
                .ForeignKey("dbo.ContactDetails", t => t.UserName)
                .ForeignKey("dbo.BloggerLogins", t => t.UserName)
                .Index(t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        FacebookContact = c.String(),
                        TwitterContact = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.BloggerLogins",
                c => new
                    {
                        BloggerUserId = c.String(nullable: false, maxLength: 128),
                        BPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BloggerUserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.String(nullable: false, maxLength: 128),
                        PostID = c.String(nullable: false, maxLength: 128),
                        CommentBy = c.String(nullable: false, maxLength: 128),
                        CommentBody = c.String(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CommentBy, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.CommentBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Occupation = c.String(),
                        Institute = c.String(),
                        ImageUrl = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        JoinDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserName)
                .ForeignKey("dbo.UserLogins", t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Comments", new[] { "CommentBy" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.Bloggers", new[] { "UserName" });
            DropIndex("dbo.Bloggers", new[] { "UserName" });
            DropIndex("dbo.Posts", new[] { "PostedBy" });
            DropForeignKey("dbo.Users", "UserName", "dbo.UserLogins");
            DropForeignKey("dbo.Comments", "CommentBy", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Bloggers", "UserName", "dbo.BloggerLogins");
            DropForeignKey("dbo.Bloggers", "UserName", "dbo.ContactDetails");
            DropForeignKey("dbo.Posts", "PostedBy", "dbo.Bloggers");
            DropTable("dbo.UserLogins");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.BloggerLogins");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.Bloggers");
            DropTable("dbo.Posts");
        }
    }
}
