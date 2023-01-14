namespace TravelApp.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public string _searchBox;
        public MainViewModel()
        {

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

        public void OnLoad()
        {
            
        }
    }
}
