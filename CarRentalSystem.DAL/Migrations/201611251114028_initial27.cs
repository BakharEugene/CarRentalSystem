namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial27 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "IdBody");
            DropColumn("dbo.Cars", "IdDriveUnit");
            DropColumn("dbo.Cars", "IdFuel");
            DropColumn("dbo.Cars", "IdMark");
            DropColumn("dbo.Cars", "IdTransmission");
            RenameColumn(table: "dbo.Cars", name: "Body_Id", newName: "IdBody");
            RenameColumn(table: "dbo.Cars", name: "DriveUnit_Id", newName: "IdDriveUnit");
            RenameColumn(table: "dbo.Cars", name: "Fuel_Id", newName: "IdFuel");
            RenameColumn(table: "dbo.Cars", name: "Mark_Id", newName: "IdMark");
            RenameColumn(table: "dbo.Cars", name: "Transmission_Id", newName: "IdTransmission");
            RenameIndex(table: "dbo.Cars", name: "IX_Body_Id", newName: "IX_IdBody");
            RenameIndex(table: "dbo.Cars", name: "IX_Mark_Id", newName: "IX_IdMark");
            RenameIndex(table: "dbo.Cars", name: "IX_DriveUnit_Id", newName: "IX_IdDriveUnit");
            RenameIndex(table: "dbo.Cars", name: "IX_Transmission_Id", newName: "IX_IdTransmission");
            RenameIndex(table: "dbo.Cars", name: "IX_Fuel_Id", newName: "IX_IdFuel");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cars", name: "IX_IdFuel", newName: "IX_Fuel_Id");
            RenameIndex(table: "dbo.Cars", name: "IX_IdTransmission", newName: "IX_Transmission_Id");
            RenameIndex(table: "dbo.Cars", name: "IX_IdDriveUnit", newName: "IX_DriveUnit_Id");
            RenameIndex(table: "dbo.Cars", name: "IX_IdMark", newName: "IX_Mark_Id");
            RenameIndex(table: "dbo.Cars", name: "IX_IdBody", newName: "IX_Body_Id");
            RenameColumn(table: "dbo.Cars", name: "IdTransmission", newName: "Transmission_Id");
            RenameColumn(table: "dbo.Cars", name: "IdMark", newName: "Mark_Id");
            RenameColumn(table: "dbo.Cars", name: "IdFuel", newName: "Fuel_Id");
            RenameColumn(table: "dbo.Cars", name: "IdDriveUnit", newName: "DriveUnit_Id");
            RenameColumn(table: "dbo.Cars", name: "IdBody", newName: "Body_Id");
            AddColumn("dbo.Cars", "IdTransmission", c => c.Int());
            AddColumn("dbo.Cars", "IdMark", c => c.Int());
            AddColumn("dbo.Cars", "IdFuel", c => c.Int());
            AddColumn("dbo.Cars", "IdDriveUnit", c => c.Int());
            AddColumn("dbo.Cars", "IdBody", c => c.Int());
        }
    }
}
