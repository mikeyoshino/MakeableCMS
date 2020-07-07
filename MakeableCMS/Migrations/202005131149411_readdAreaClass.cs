namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdAreaClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "AreaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "AreaId");
            AddForeignKey("dbo.Categories", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "AreaId", "dbo.Areas");
            DropIndex("dbo.Categories", new[] { "AreaId" });
            DropColumn("dbo.Categories", "AreaId");
            DropTable("dbo.Areas");
        }
    }
}
