namespace MusicShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Long(nullable: false, identity: true),
                        GenreId = c.Long(nullable: false),
                        AlbumTitle = c.String(nullable: false),
                        ArtistName = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        CoverFileName = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsNewArrivals = c.Boolean(nullable: false),
                        IsBestseller = c.Boolean(nullable: false),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IconFilename = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Album_AlbumId = c.Long(),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.Album_AlbumId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 150),
                        Address = c.String(nullable: false, maxLength: 150),
                        CodeAndCity = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropIndex("dbo.OrderItems", new[] { "Album_AlbumId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Albums", new[] { "GenreId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Genres");
            DropTable("dbo.Albums");
        }
    }
}
