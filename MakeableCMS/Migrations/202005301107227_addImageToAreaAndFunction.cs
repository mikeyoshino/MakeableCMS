namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageToAreaAndFunction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImagePath", c => c.String());
            AddColumn("dbo.Areas", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Areas", "ImagePath");
            DropColumn("dbo.Categories", "ImagePath");
        }
    }
}
