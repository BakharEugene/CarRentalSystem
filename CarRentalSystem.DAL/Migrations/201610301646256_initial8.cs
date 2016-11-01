namespace CarRentalSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarkPictures", "MarkId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarkPictures", "MarkId");
        }
    }
}
