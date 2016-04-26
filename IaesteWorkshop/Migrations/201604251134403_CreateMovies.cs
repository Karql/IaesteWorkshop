namespace IaesteWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovies : DbMigration
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
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        TrailerUrl = c.String(),
                        Cast = c.String(nullable: false),
                        Direction = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieFiles", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieFiles", new[] { "MovieId" });
            DropTable("dbo.Movies");
            DropTable("dbo.MovieFiles");
        }
    }
}
