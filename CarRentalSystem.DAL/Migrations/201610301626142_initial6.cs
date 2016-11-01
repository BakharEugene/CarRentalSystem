namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MarkPictures", "MarkId", "dbo.Marks");
            DropIndex("dbo.MarkPictures", new[] { "MarkId" });
            DropTable("dbo.MarkPictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MarkPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarkId = c.Int(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MarkPictures", "MarkId");
            AddForeignKey("dbo.MarkPictures", "MarkId", "dbo.Marks", "Id");
        }
    }
}
