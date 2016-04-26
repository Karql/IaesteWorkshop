namespace IaesteWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieFiles",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Movies", t => t.MovieId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ReviewerName = c.String(maxLength: 100),
                        ReviewerEmail = c.String(maxLength: 100),
                        Review = c.String(),
                        ReviewType = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieReviews", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieFiles", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieReviews", new[] { "MovieId" });
            DropIndex("dbo.MovieFiles", new[] { "MovieId" });
            DropTable("dbo.MovieReviews");
            DropTable("dbo.MovieFiles");
        }
    }
}
