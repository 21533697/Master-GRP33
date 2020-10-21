namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraNewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "isVisible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Discounts", "isVisible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discounts", "isVisible");
            DropColumn("dbo.Categories", "isVisible");
        }
    }
}
