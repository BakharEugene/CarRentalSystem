namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pictures", newName: "CarPictures");
            CreateTable(
                "dbo.MarkPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Mark_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marks", t => t.Mark_Id)
                .Index(t => t.Mark_Id);
            
            DropColumn("dbo.Marks", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marks", "Picture", c => c.String());
            DropForeignKey("dbo.MarkPictures", "Mark_Id", "dbo.Marks");
            DropIndex("dbo.MarkPictures", new[] { "Mark_Id" });
            DropTable("dbo.MarkPictures");
            RenameTable(name: "dbo.CarPictures", newName: "Pictures");
        }
    }
}
