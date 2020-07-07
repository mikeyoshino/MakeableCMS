namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDescriptionFromApplication : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Applications", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "Description", c => c.String());
        }
    }
}
