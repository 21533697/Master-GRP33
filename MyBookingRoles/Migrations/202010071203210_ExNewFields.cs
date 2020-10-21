namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExNewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentAmount");
        }
    }
}
