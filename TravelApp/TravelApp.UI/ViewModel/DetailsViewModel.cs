using TravelApp.Model;

namespace TravelApp.UI.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        private Travel _travel;
        private string _city;

        public DetailsViewModel(Travel travel)
        {
            Travel = travel;
            City = travel.City;
        }

        public Travel Travel
        {
            get => _travel;
            set
            {
                _travel = value;
                OnPropertyChanged();
            }
        }

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
