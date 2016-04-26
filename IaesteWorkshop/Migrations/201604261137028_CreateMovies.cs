namespace IaesteWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovies : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Movies");
        }
    }
}
