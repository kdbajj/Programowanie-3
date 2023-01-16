using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TravelApp.Model;
using TravelApp.UI.Data;

namespace TravelApp.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public string _searchBox;
        private ITravelAppDataService _travelAppDataService;

        public MainViewModel(ITravelAppDataService travelAppDataService)
        {
            _travelAppDataService = travelAppDataService;
            Travels = new ObservableCollection<Travel>();
        }

        public string SearchBox
        {
            get => _searchBox;
            set
            {
                _searchBox = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Travel> Travels { get; set; }

        public async Task OnLoad()
        {
            var travelsData = await _travelAppDataService.GetAll();

            Travels.Clear();

            foreach (var travel in travelsData)
            {
                Travels.Add(travel);
            }
        }
    }
}
