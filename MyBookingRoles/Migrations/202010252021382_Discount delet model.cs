namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Discountdeletmodel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Discounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscId = c.Int(nullable: false, identity: true),
                        DiscName = c.String(),
                        DiscPercentage = c.Int(nullable: false),
                        isVisible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DiscId);
            
        }
    }
}
