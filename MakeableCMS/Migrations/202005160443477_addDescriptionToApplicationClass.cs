namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDescriptionToApplicationClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "Description");
        }
    }
}
