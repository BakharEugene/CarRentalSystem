namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHistories", "IdStatus", c => c.Int());
            CreateIndex("dbo.OrderHistories", "IdStatus");
            AddForeignKey("dbo.OrderHistories", "IdStatus", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderHistories", "IdStatus", "dbo.Status");
            DropIndex("dbo.OrderHistories", new[] { "IdStatus" });
            DropColumn("dbo.OrderHistories", "IdStatus");
        }
    }
}
