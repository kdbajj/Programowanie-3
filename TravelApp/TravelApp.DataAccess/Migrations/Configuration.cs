namespace TravelApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TravelApp.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TravelApp.DataAccess.TravelAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TravelApp.DataAccess.TravelAppDbContext context)
        {
            context.Travels.AddOrUpdate(
               travels => travels.City,
               new Travel { City = "Paris" }
               );
        }
    }
}
