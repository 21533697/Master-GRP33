namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrandVisibility : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "isVisible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "isVisible");
        }
    }
}
