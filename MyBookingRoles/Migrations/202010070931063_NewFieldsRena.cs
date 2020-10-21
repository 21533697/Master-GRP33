namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFieldsRena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DiscountId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "DsicountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DsicountId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "DiscountId");
        }
    }
}
