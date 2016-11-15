namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bodies", "Name", c => c.String());
            AddColumn("dbo.DriveUnits", "Name", c => c.String());
            AddColumn("dbo.Fuels", "Name", c => c.String());
            AddColumn("dbo.Transmissions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transmissions", "Name");
            DropColumn("dbo.Fuels", "Name");
            DropColumn("dbo.DriveUnits", "Name");
            DropColumn("dbo.Bodies", "Name");
        }
    }
}
