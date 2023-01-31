using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.DataAccess;
using TravelApp.Model;

namespace TravelApp.UI.Data
{
    public class TravelAppDataService : ITravelAppDataService
    {
        private Func<TravelAppDbContext> _contextCreator;

        public TravelAppDataService(Func<TravelAppDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public async Task<List<Travel>> GetAll()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Travels.AsNoTracking().ToListAsync();
            }
        }

        public async Task UpdateTravel(Travel travel)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Travels.Attach(travel);
                ctx.Entry(travel).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
