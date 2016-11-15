namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriveUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "IdBody", c => c.Int());
            AddColumn("dbo.Cars", "IdDriveUnit", c => c.Int());
            AddColumn("dbo.Cars", "IdTransmission", c => c.Int());
            AddColumn("dbo.Cars", "IdFuel", c => c.Int());
            AddColumn("dbo.Cars", "Body_Id", c => c.Int());
            AddColumn("dbo.Cars", "DriveUnit_Id", c => c.Int());
            AddColumn("dbo.Cars", "Fuel_Id", c => c.Int());
            AddColumn("dbo.Cars", "Transmission_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Body_Id");
            CreateIndex("dbo.Cars", "DriveUnit_Id");
            CreateIndex("dbo.Cars", "Fuel_Id");
            CreateIndex("dbo.Cars", "Transmission_Id");
            AddForeignKey("dbo.Cars", "Body_Id", "dbo.Bodies", "Id");
            AddForeignKey("dbo.Cars", "DriveUnit_Id", "dbo.DriveUnits", "Id");
            AddForeignKey("dbo.Cars", "Fuel_Id", "dbo.Fuels", "Id");
            AddForeignKey("dbo.Cars", "Transmission_Id", "dbo.Transmissions", "Id");
            DropColumn("dbo.Cars", "Fuel");
            DropColumn("dbo.Cars", "Transmission");
            DropColumn("dbo.Cars", "Body");
            DropColumn("dbo.Cars", "Drive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Drive", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Body", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Transmission", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Fuel", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "Transmission_Id", "dbo.Transmissions");
            DropForeignKey("dbo.Cars", "Fuel_Id", "dbo.Fuels");
            DropForeignKey("dbo.Cars", "DriveUnit_Id", "dbo.DriveUnits");
            DropForeignKey("dbo.Cars", "Body_Id", "dbo.Bodies");
            DropIndex("dbo.Cars", new[] { "Transmission_Id" });
            DropIndex("dbo.Cars", new[] { "Fuel_Id" });
            DropIndex("dbo.Cars", new[] { "DriveUnit_Id" });
            DropIndex("dbo.Cars", new[] { "Body_Id" });
            DropColumn("dbo.Cars", "Transmission_Id");
            DropColumn("dbo.Cars", "Fuel_Id");
            DropColumn("dbo.Cars", "DriveUnit_Id");
            DropColumn("dbo.Cars", "Body_Id");
            DropColumn("dbo.Cars", "IdFuel");
            DropColumn("dbo.Cars", "IdTransmission");
            DropColumn("dbo.Cars", "IdDriveUnit");
            DropColumn("dbo.Cars", "IdBody");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Fuels");
            DropTable("dbo.DriveUnits");
            DropTable("dbo.Bodies");
        }
    }
}
