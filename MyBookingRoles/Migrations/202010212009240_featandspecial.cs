namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featandspecial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsFeatured", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsOnSpecial", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsOnSpecial");
            DropColumn("dbo.Products", "IsFeatured");
        }
    }
}
