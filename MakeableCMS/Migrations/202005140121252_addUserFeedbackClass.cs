namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserFeedbackClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        Comments = c.String(),
                        UserRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFeedbacks", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.UserFeedbacks", new[] { "ApplicationId" });
            DropTable("dbo.UserFeedbacks");
        }
    }
}
