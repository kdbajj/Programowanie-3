using System.Collections.ObjectModel;
using TravelApp.Model;

namespace TravelApp.UI.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        private string _city;

        public DetailsViewModel(Travel travel)
        {
            Travel = new ObservableCollection<Travel>();
            Travel.Add(travel);

            City = travel.City;
        }

        public ObservableCollection<Travel> Travel { get; set; }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }


    }
}
