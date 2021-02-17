namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Creator_Id" });
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 500),
                        CommentCreator_Id = c.String(maxLength: 128),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentCreator_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.CommentCreator_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WaitingFlag = c.Boolean(nullable: false),
                        ApproveFlag = c.Boolean(nullable: false),
                        RejectFlag = c.Boolean(nullable: false),
                        BlockFlag = c.Boolean(nullable: false),
                        SpamFlag = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Receiver_Id = c.String(maxLength: 128),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Receiver_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageContent = c.String(nullable: false),
                        IsSeen = c.Boolean(nullable: false),
                        Friendship_Id = c.Int(),
                        MessageReceiver_Id = c.String(maxLength: 128),
                        MessageSender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Friendships", t => t.Friendship_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.MessageReceiver_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.MessageSender_Id)
                .Index(t => t.Friendship_Id)
                .Index(t => t.MessageReceiver_Id)
                .Index(t => t.MessageSender_Id);
            
            AlterColumn("dbo.Posts", "Creator_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "Creator_Id");
            AddForeignKey("dbo.Posts", "Creator_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "MessageSender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "MessageReceiver_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "Friendship_Id", "dbo.Friendships");
            DropForeignKey("dbo.Friendships", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friendships", "Receiver_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Comments", "CommentCreator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "MessageSender_Id" });
            DropIndex("dbo.Messages", new[] { "MessageReceiver_Id" });
            DropIndex("dbo.Messages", new[] { "Friendship_Id" });
            DropIndex("dbo.Friendships", new[] { "Sender_Id" });
            DropIndex("dbo.Friendships", new[] { "Receiver_Id" });
            DropIndex("dbo.Posts", new[] { "Creator_Id" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "CommentCreator_Id" });
            AlterColumn("dbo.Posts", "Creator_Id", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Messages");
            DropTable("dbo.Friendships");
            DropTable("dbo.Comments");
            CreateIndex("dbo.Posts", "Creator_Id");
            AddForeignKey("dbo.Posts", "Creator_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
