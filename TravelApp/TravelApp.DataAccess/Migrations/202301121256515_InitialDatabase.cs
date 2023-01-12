namespace TravelApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Travel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        User = c.String(maxLength: 50),
                        Food = c.String(),
                        Price = c.Single(nullable: false),
                        Transport = c.String(maxLength: 50),
                        HotelName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Travel");
        }
    }
}
