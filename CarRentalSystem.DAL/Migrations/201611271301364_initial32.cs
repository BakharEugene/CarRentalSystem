namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHistories", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderHistories", "EndDate", c => c.String());
            DropColumn("dbo.OrderHistories", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderHistories", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.OrderHistories", "EndDate");
            DropColumn("dbo.OrderHistories", "StartDate");
        }
    }
}
