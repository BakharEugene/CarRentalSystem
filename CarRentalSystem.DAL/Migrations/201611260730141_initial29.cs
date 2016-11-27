namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "IdStatus", c => c.Int());
            CreateIndex("dbo.Cars", "IdStatus");
            AddForeignKey("dbo.Cars", "IdStatus", "dbo.Status", "Id");
            DropColumn("dbo.OrderHistories", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderHistories", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "IdStatus", "dbo.Status");
            DropIndex("dbo.Cars", new[] { "IdStatus" });
            DropColumn("dbo.Cars", "IdStatus");
            DropTable("dbo.Status");
        }
    }
}
