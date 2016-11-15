namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial23 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Humen");
            AddColumn("dbo.Humen", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Humen", "Discriminator");
            RenameTable(name: "dbo.Humen", newName: "Users");
        }
    }
}
