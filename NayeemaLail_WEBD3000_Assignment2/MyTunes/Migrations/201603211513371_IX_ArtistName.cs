namespace MyTunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IX_ArtistName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Artist", new string[] { "Name" },
               true, "IX_ArtistName");

        }

        public override void Down()
        {
            DropIndex("dbo.Artist", "IX_ArtistName");

        }
    }
}
