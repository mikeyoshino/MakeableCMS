namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAppOsClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppOs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Applications", "AppOsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Applications", "AppOsId");
            AddForeignKey("dbo.Applications", "AppOsId", "dbo.AppOs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "AppOsId", "dbo.AppOs");
            DropIndex("dbo.Applications", new[] { "AppOsId" });
            DropColumn("dbo.Applications", "AppOsId");
            DropTable("dbo.AppOs");
        }
    }
}
