namespace StudyTimeHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        StudentId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Start = c.DateTime(),
                        End = c.DateTime(),
                        EventRepeat = c.Boolean(),
                        IsAllDay = c.Boolean(),
                        ThemeColor = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        StudyTimeHelperUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.StudyTimeHelperUser", t => t.StudyTimeHelperUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.StudyTimeHelperUser_Id);
            
            CreateTable(
                "dbo.StudyTimeHelperUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        StudyTimeHelperUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudyTimeHelperUser", t => t.StudyTimeHelperUser_Id)
                .Index(t => t.StudyTimeHelperUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        StudyTimeHelperUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.StudyTimeHelperUser", t => t.StudyTimeHelperUser_Id)
                .Index(t => t.StudyTimeHelperUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "StudyTimeHelperUser_Id", "dbo.StudyTimeHelperUser");
            DropForeignKey("dbo.IdentityUserLogin", "StudyTimeHelperUser_Id", "dbo.StudyTimeHelperUser");
            DropForeignKey("dbo.IdentityUserClaim", "StudyTimeHelperUser_Id", "dbo.StudyTimeHelperUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "StudyTimeHelperUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "StudyTimeHelperUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "StudyTimeHelperUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.StudyTimeHelperUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Event");
        }
    }
}
