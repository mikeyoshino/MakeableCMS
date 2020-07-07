namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAreaToArticle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            AddColumn("dbo.Articles", "AreaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "AreaId");
            AddForeignKey("dbo.Articles", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
            DropColumn("dbo.Articles", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Articles", "AreaId", "dbo.Areas");
            DropIndex("dbo.Articles", new[] { "AreaId" });
            DropColumn("dbo.Articles", "AreaId");
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
