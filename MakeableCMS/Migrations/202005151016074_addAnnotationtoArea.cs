namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnnotationtoArea : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Areas", "AreaName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Areas", "AreaName", c => c.String());
        }
    }
}
