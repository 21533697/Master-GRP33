namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ProdName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "ProdName");
        }
    }
}
