namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial24 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Humen", newName: "Users");
            DropColumn("dbo.Users", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameTable(name: "dbo.Users", newName: "Humen");
        }
    }
}
