namespace MakeableCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'371d94af-1901-4bcc-ae93-00cd641f8425', N'yoshinotsubagi@gmail.com', 0, N'AIYeBBGlNLOb4DAQxA/z3QqN5750EQLCvjdRXv63Qg+ixsQzIqQZevnTT29URNOXeQ==', N'36762cf2-76cb-4ef9-bb74-d96f61b26c21', NULL, 0, 0, NULL, 1, 0, N'yoshinotsubagi@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e8802f2f-f65a-4c49-a79c-5d351096d6e2', N'admin@makeable.com', 0, N'AH7RGpYqyTMr1qVPwLwqsgyKDea8VVzPrtwQNrUxu3kKQigom+ty7F+2K6ubzEkwTA==', N'bf4f7194-b540-458d-924b-332a67bdfff7', NULL, 0, 0, NULL, 1, 0, N'admin@makeable.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'59871a06-830d-4294-99a2-386a4275690f', N'CanManageAll')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e8802f2f-f65a-4c49-a79c-5d351096d6e2', N'59871a06-830d-4294-99a2-386a4275690f')
");
        }
        
        public override void Down()
        {
        }
    }
}
