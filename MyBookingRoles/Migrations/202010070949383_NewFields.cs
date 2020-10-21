namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Discount_DiscId", "dbo.Discounts");
            DropIndex("dbo.Products", new[] { "Discount_DiscId" });
            AddColumn("dbo.Discounts", "DiscPercentage", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "IsVisible", c => c.Boolean(nullable: false));
            DropColumn("dbo.Discounts", "DiscPrice");
            DropColumn("dbo.Products", "NewPrice");
            DropColumn("dbo.Products", "DiscountId");
            DropColumn("dbo.Products", "Discount_DiscId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Discount_DiscId", c => c.Int());
            AddColumn("dbo.Products", "DiscountId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "NewPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Discounts", "DiscPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Products", "IsVisible");
            DropColumn("dbo.Discounts", "DiscPercentage");
            CreateIndex("dbo.Products", "Discount_DiscId");
            AddForeignKey("dbo.Products", "Discount_DiscId", "dbo.Discounts", "DiscId");
        }
    }
}
