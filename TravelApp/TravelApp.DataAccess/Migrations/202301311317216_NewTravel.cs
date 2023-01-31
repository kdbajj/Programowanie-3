namespace TravelApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTravel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Travel", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Travel", "User", c => c.String(maxLength: 50));
        }
    }
}
