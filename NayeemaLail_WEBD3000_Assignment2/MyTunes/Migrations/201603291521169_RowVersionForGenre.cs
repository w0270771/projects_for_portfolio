namespace MyTunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RowVersionForGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genre", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genre", "RowVersion");
        }
    }
}
