namespace MusicShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "ShortDescription");
        }
    }
}
