namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial12 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Administrators", newName: "Users");
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
            DropColumn("dbo.Users", "DPassword");
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Telephone = c.String(),
                        Skype = c.String(),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "DPassword", c => c.String());
            DropColumn("dbo.Users", "ConfirmPassword");
            RenameTable(name: "dbo.Users", newName: "Administrators");
        }
    }
}
