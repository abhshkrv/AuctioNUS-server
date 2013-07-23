namespace AuctioNUS.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class topbid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deals", "topBid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deals", "topBid");
        }
    }
}
