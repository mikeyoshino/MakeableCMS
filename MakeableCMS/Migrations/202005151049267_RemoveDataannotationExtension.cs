namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDataannotationExtension : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "Name", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Applications", "AppUrl", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "AppUrl", c => c.String(maxLength: 200));
            AlterColumn("dbo.Applications", "Name", c => c.String(maxLength: 120));
        }
    }
}
