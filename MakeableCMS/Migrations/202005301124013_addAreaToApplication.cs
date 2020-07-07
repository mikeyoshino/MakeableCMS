namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAreaToApplication : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "AppOsId", "dbo.AppOs");
            DropForeignKey("dbo.Applications", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.UserFeedbacks", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Categories", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Articles", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            AddColumn("dbo.Applications", "AreaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Applications", "AreaId");
            AddForeignKey("dbo.Applications", "AreaId", "dbo.Areas", "Id");
            AddForeignKey("dbo.Applications", "AppOsId", "dbo.AppOs", "Id");
            AddForeignKey("dbo.Applications", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.UserFeedbacks", "ApplicationId", "dbo.Applications", "Id");
            AddForeignKey("dbo.Categories", "AreaId", "dbo.Areas", "Id");
            AddForeignKey("dbo.Articles", "AreaId", "dbo.Areas", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Articles", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Categories", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.UserFeedbacks", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Applications", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Applications", "AppOsId", "dbo.AppOs");
            DropForeignKey("dbo.Applications", "AreaId", "dbo.Areas");
            DropIndex("dbo.Applications", new[] { "AreaId" });
            DropColumn("dbo.Applications", "AreaId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserFeedbacks", "ApplicationId", "dbo.Applications", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Applications", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Applications", "AppOsId", "dbo.AppOs", "Id", cascadeDelete: true);
        }
    }
}
