namespace AuctioNUS.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        DealID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        type = c.Boolean(nullable: false),
                        bookName = c.String(),
                        ISBN = c.String(),
                        price = c.Single(nullable: false),
                        imgUrl = c.String(),
                    })
                .PrimaryKey(t => t.DealID);
            
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        BidID = c.Int(nullable: false, identity: true),
                        DealID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BidID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleID = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        name = c.String(),
                        recommendedBookName = c.String(),
                    })
                .PrimaryKey(t => t.ModuleID);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        settingByte = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SettingID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        matricNo = c.String(),
                        email = c.String(),
                        phoneNo = c.String(),
                        phoneNumberVisibility = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Settings");
            DropTable("dbo.Modules");
            DropTable("dbo.Bids");
            DropTable("dbo.Deals");
        }
    }
}
