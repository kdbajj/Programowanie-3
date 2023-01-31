namespace TravelApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Resources;
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
               new Travel { City = "Paris", Price = 1500F, Country = "France", Food = "Breakfast", HotelName = "EiffelTower", Transport = "Plane" },


               new Travel { City = "Warsaw", Price = 890F, Country = "Poland", Food = "Breakfast, Dinner", HotelName = "Hilton", Transport = "Bus"},
               new Travel { City = "London", Price = 1700F, Country = "Great Britain", Food = "All inclusive", HotelName = "London View", Transport = "Plane" },
               new Travel { City = "Berlin", Price = 1000F, Country = "Germany", Food = "Breakfast", HotelName = "BerlinGuide", Transport = "Bus" },
               new Travel { City = "Oslo", Price = 1100F, Country = "Norway", Food = "Breakfast, Dinner", HotelName = "OsloTourist", Transport = "Plane" },
               new Travel { City = "Cracow", Price = 800F, Country = "Poland", Food = "Breakfast", HotelName = "Smok Wawelski", Transport = "Bus" },
               new Travel { City = "Manchester", Price = 1500F, Country = "Great Britain", Food = "Dinner", HotelName = "Manchester Piccadilly Hotel", Transport = "Plane" },
               new Travel { City = "Dublin", Price = 1550F, Country = "Ireland", Food = "Breakfast", HotelName = "Dublin Apartment", Transport = "Plane" }

               );
        }
    }
}
