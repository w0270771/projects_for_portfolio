namespace MyTunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class IX_MediaCategoryName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MediaCategory", new string[] { "Name" },
                  true, "IX_MediaCategoryName");
        }

        public override void Down()
        {
            DropIndex("dbo.MediaCategory", "IX_MediaCategoryName");
        }
    }
}
