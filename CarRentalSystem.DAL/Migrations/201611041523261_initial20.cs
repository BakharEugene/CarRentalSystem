namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        BodyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bodies", t => t.BodyId)
                .Index(t => t.BodyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BodyPictures", "BodyId", "dbo.Bodies");
            DropIndex("dbo.BodyPictures", new[] { "BodyId" });
            DropTable("dbo.BodyPictures");
        }
    }
}
