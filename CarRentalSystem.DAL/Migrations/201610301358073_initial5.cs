namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CarPictures", name: "Car_Id", newName: "CarId");
            RenameColumn(table: "dbo.MarkPictures", name: "Mark_Id", newName: "MarkId");
            RenameIndex(table: "dbo.CarPictures", name: "IX_Car_Id", newName: "IX_CarId");
            RenameIndex(table: "dbo.MarkPictures", name: "IX_Mark_Id", newName: "IX_MarkId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MarkPictures", name: "IX_MarkId", newName: "IX_Mark_Id");
            RenameIndex(table: "dbo.CarPictures", name: "IX_CarId", newName: "IX_Car_Id");
            RenameColumn(table: "dbo.MarkPictures", name: "MarkId", newName: "Mark_Id");
            RenameColumn(table: "dbo.CarPictures", name: "CarId", newName: "Car_Id");
        }
    }
}
