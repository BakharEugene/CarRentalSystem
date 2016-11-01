namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Marks", "PictureId", "dbo.Pictures");
            DropIndex("dbo.Marks", new[] { "PictureId" });
            AddColumn("dbo.Marks", "Picture", c => c.String());
            DropColumn("dbo.Marks", "PictureId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marks", "PictureId", c => c.Int());
            DropColumn("dbo.Marks", "Picture");
            CreateIndex("dbo.Marks", "PictureId");
            AddForeignKey("dbo.Marks", "PictureId", "dbo.Pictures", "Id");
        }
    }
}
