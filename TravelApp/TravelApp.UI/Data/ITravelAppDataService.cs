using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Model;

namespace TravelApp.UI.Data
{
    public interface ITravelAppDataService
    {
        Task<List<Travel>> GetAll();
    }
}