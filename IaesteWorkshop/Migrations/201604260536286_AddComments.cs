namespace IaesteWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ReplyToCommentId = c.Int(),
                        AuthorName = c.String(maxLength: 100),
                        AuthorEmail = c.String(maxLength: 100),
                        Comment = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.MovieComments", t => t.ReplyToCommentId)
                .Index(t => t.MovieId)
                .Index(t => t.ReplyToCommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieComments", "ReplyToCommentId", "dbo.MovieComments");
            DropForeignKey("dbo.MovieComments", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieComments", new[] { "ReplyToCommentId" });
            DropIndex("dbo.MovieComments", new[] { "MovieId" });
            DropTable("dbo.MovieComments");
        }
    }
}
