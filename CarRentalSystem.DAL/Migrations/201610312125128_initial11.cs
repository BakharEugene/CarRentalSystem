namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String());
            DropColumn("dbo.Customers", "DPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DPassword", c => c.String());
            DropColumn("dbo.Customers", "ConfirmPassword");
        }
    }
}
