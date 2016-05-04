namespace MyTunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IX_GenreName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genre", "Name", c => c.String(nullable: false, maxLength: 120));
            CreateIndex("dbo.Genre", "Name", unique: true, name: "IX_GenreName");
            
        }
        
        public override void Down()
        {
            
            DropIndex("dbo.Genre", "IX_GenreName");
            AlterColumn("dbo.Genre", "Name", c => c.String(maxLength: 120));
        }
    }
}
