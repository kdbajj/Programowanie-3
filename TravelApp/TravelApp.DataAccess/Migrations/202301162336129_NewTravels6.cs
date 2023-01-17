namespace TravelApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTravels6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Travel", "TravelImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Travel", "TravelImage");
        }
    }
}
