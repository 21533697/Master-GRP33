namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFieldsAndDiscount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscId = c.Int(nullable: false, identity: true),
                        DiscName = c.String(),
                        DiscPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DiscId);
            
            AddColumn("dbo.Products", "NewPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "InStoreQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "DsicountId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Discount_DiscId", c => c.Int());
            CreateIndex("dbo.Products", "Discount_DiscId");
            AddForeignKey("dbo.Products", "Discount_DiscId", "dbo.Discounts", "DiscId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Discount_DiscId", "dbo.Discounts");
            DropIndex("dbo.Products", new[] { "Discount_DiscId" });
            DropColumn("dbo.Products", "Discount_DiscId");
            DropColumn("dbo.Products", "DsicountId");
            DropColumn("dbo.Products", "InStoreQuantity");
            DropColumn("dbo.Products", "NewPrice");
            DropTable("dbo.Discounts");
        }
    }
}
