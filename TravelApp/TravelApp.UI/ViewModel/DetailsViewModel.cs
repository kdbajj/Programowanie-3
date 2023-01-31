using System.Collections.ObjectModel;
using TravelApp.Model;
using TravelApp.UI.Command;

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

            OpenBasketCommand = new DelegateCommand(OpenBasket);
        }

        public ObservableCollection<Travel> Travel { get; set; }
        public DelegateCommand OpenBasketCommand { get; set; }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }
        private void OpenBasket(object? obj)
        {

        }
    }
}
