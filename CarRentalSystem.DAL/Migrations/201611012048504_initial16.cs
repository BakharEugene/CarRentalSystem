namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Drive", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Drive");
        }
    }
}
