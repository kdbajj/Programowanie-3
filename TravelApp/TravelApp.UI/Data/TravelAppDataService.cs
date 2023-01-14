using System.Collections.Generic;
using System.Linq;
using TravelApp.DataAccess;
using TravelApp.Model;

namespace TravelApp.UI.Data
{
    public class TravelAppDataService
    {
        public IEnumerable<Travel> GetAll()
        {
            using (var ctx = new TravelAppDbContext())
            {
                return ctx.Travels.AsNoTracking().ToList();
            }
        }
    }
}
