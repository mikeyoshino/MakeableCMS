namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Applications", "AppOs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "AppOs", c => c.String());
        }
    }
}
