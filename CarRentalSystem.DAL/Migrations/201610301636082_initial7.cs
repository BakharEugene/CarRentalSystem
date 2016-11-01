namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarkPictures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marks", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MarkPictures", "Id", "dbo.Marks");
            DropIndex("dbo.MarkPictures", new[] { "Id" });
            DropTable("dbo.MarkPictures");
        }
    }
}
