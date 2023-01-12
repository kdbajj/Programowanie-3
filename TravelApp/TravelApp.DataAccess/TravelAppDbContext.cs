
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using TravelApp.Model;

namespace TravelApp.DataAccess
{
    public class TravelAppDbContext: DbContext
    {
        public TravelAppDbContext():base("TravelApp")
        {

        }

        public DbSet<Travel> Travels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

           
        }

    }
}
