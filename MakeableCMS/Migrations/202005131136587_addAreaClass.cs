namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAreaClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Organizations", new[] { "CategoryId" });
            AddColumn("dbo.Applications", "AppStoreRating", c => c.Int(nullable: false));
            AddColumn("dbo.Applications", "AppOs", c => c.String());
            AddColumn("dbo.Applications", "PostDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applications", "IsLastUpdate", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applications", "UserfulRate", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "Description", c => c.String());
            DropColumn("dbo.Applications", "InstallNumber");
            DropColumn("dbo.Applications", "IsAppleStore");
            DropColumn("dbo.Applications", "RatingExternal");
            DropColumn("dbo.Applications", "RatingTeam");
            DropColumn("dbo.Applications", "Function");
            DropTable("dbo.Organizations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Applications", "Function", c => c.String());
            AddColumn("dbo.Applications", "RatingTeam", c => c.Int(nullable: false));
            AddColumn("dbo.Applications", "RatingExternal", c => c.Int(nullable: false));
            AddColumn("dbo.Applications", "IsAppleStore", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applications", "InstallNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "Description", c => c.String(maxLength: 255));
            DropColumn("dbo.Applications", "UserfulRate");
            DropColumn("dbo.Applications", "IsLastUpdate");
            DropColumn("dbo.Applications", "PostDate");
            DropColumn("dbo.Applications", "AppOs");
            DropColumn("dbo.Applications", "AppStoreRating");
            CreateIndex("dbo.Organizations", "CategoryId");
            AddForeignKey("dbo.Organizations", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
