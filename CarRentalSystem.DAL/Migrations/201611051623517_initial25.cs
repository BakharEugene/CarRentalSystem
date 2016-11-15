namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(),
                        UserId = c.Int(),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CarId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderHistories", "CarId", "dbo.Cars");
            DropIndex("dbo.OrderHistories", new[] { "UserId" });
            DropIndex("dbo.OrderHistories", new[] { "CarId" });
            DropTable("dbo.OrderHistories");
        }
    }
}
