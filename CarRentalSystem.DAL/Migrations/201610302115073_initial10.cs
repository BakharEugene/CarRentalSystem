namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Mileage", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Fuel", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Transmission", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Body", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Body");
            DropColumn("dbo.Cars", "Transmission");
            DropColumn("dbo.Cars", "Fuel");
            DropColumn("dbo.Cars", "Mileage");
        }
    }
}
