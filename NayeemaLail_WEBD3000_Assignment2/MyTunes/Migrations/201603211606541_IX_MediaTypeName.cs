namespace MyTunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IX_MediaTypeName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MediaType", new string[] { "Name" },
               true, "IX_MediaTypeName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MediaType", "IX_MediaTypeName");
        }
    }
}
