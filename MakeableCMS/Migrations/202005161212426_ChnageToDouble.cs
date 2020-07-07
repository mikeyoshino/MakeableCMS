namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChnageToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "AppStoreRating", c => c.Double(nullable: false));
            AlterColumn("dbo.Applications", "UserfulRate", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "UserfulRate", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "AppStoreRating", c => c.Int(nullable: false));
        }
    }
}
