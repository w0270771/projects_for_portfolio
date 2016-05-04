namespace MyTunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Album", "ReleaseDate");
        }
    }
}
