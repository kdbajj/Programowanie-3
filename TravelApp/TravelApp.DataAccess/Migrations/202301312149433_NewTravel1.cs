namespace TravelApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTravel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Travel", "User_Id", c => c.Int());
            CreateIndex("dbo.Travel", "User_Id");
            AddForeignKey("dbo.Travel", "User_Id", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Travel", "User_Id", "dbo.User");
            DropIndex("dbo.Travel", new[] { "User_Id" });
            DropColumn("dbo.Travel", "User_Id");
            DropTable("dbo.User");
        }
    }
}
