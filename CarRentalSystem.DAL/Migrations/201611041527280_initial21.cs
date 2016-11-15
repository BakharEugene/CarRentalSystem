namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BodyPictures", "BodyId", "dbo.Bodies");
            DropIndex("dbo.BodyPictures", new[] { "BodyId" });
            DropTable("dbo.BodyPictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BodyPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        BodyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.BodyPictures", "BodyId");
            AddForeignKey("dbo.BodyPictures", "BodyId", "dbo.Bodies", "Id");
        }
    }
}
