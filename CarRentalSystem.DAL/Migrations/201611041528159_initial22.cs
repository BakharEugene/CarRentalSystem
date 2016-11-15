namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyPictures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Path = c.String(),
                        BodyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bodies", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BodyPictures", "Id", "dbo.Bodies");
            DropIndex("dbo.BodyPictures", new[] { "Id" });
            DropTable("dbo.BodyPictures");
        }
    }
}
