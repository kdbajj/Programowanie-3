using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Model;
using TravelApp.UI.Command;
using TravelApp.UI.Data;

namespace TravelApp.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public string _searchBox;
        private ITravelAppDataService _travelAppDataService;
        private bool _isDetailsWindowOpen;

        public MainViewModel(ITravelAppDataService travelAppDataService)
        {
            _travelAppDataService = travelAppDataService;
            Travels = new ObservableCollection<Travel>();

            OpenDetailsWindowCommand = new DelegateCommand(OpenDetailsWindow);
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
        public DelegateCommand OpenDetailsWindowCommand { get; set; }

        public async Task OnLoad()
        {
            var travelsData = await _travelAppDataService.GetAll();

            Travels.Clear();

            foreach (var travel in travelsData)
            {
                Travels.Add(travel);
            }
        }

        private void OpenDetailsWindow(object? obj)
        {
            //if (_isDetailsWindowOpen)
            //{
            //    return;
            //}

            //_isDetailsWindowOpen = true;

            Travel? travel;

            try
            {
                travel = obj as Travel;
            }
            catch
            {
                return;
            }

            if (travel is null)
            {
                return;
            }

            var newWindow = new DetailsWindow();
            var detailsViewModel = new DetailsViewModel(travel);


            //detailsViewModel.Travel = travel;
            newWindow.DataContext = detailsViewModel;
            newWindow.Show();

            //_isDetailsWindowOpen = false;
        }
    }
}
