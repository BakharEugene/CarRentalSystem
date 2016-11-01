namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pictures", name: "CarId", newName: "Car_Id");
            RenameIndex(table: "dbo.Pictures", name: "IX_CarId", newName: "IX_Car_Id");
            AddColumn("dbo.Marks", "PictureId", c => c.Int());
            CreateIndex("dbo.Marks", "PictureId");
            AddForeignKey("dbo.Marks", "PictureId", "dbo.Pictures", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "PictureId", "dbo.Pictures");
            DropIndex("dbo.Marks", new[] { "PictureId" });
            DropColumn("dbo.Marks", "PictureId");
            RenameIndex(table: "dbo.Pictures", name: "IX_Car_Id", newName: "IX_CarId");
            RenameColumn(table: "dbo.Pictures", name: "Car_Id", newName: "CarId");
        }
    }
}
