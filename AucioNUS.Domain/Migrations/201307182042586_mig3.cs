namespace AuctioNUS.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deals", "author", c => c.String());
            AddColumn("dbo.Deals", "closingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deals", "closingDate");
            DropColumn("dbo.Deals", "author");
        }
    }
}
