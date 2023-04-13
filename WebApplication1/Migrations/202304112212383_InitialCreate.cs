namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Tags = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.String(),
                        Comment = c.String(),
                        Like = c.Boolean(nullable: false),
                        Deslike = c.Boolean(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        Award = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.ToWatchMovieLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MoviesTags = c.String(),
                        MovieIds = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.WatchedMovieLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MoviesIds = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Updated_at = c.DateTime(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PersonId", "dbo.People");
            DropForeignKey("dbo.WatchedMovieLists", "Person_Id", "dbo.People");
            DropForeignKey("dbo.ToWatchMovieLists", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Ratings", "OwnerId", "dbo.People");
            DropIndex("dbo.Users", new[] { "PersonId" });
            DropIndex("dbo.WatchedMovieLists", new[] { "Person_Id" });
            DropIndex("dbo.ToWatchMovieLists", new[] { "Person_Id" });
            DropIndex("dbo.Ratings", new[] { "OwnerId" });
            DropTable("dbo.Users");
            DropTable("dbo.WatchedMovieLists");
            DropTable("dbo.ToWatchMovieLists");
            DropTable("dbo.Ratings");
            DropTable("dbo.People");
        }
    }
}
