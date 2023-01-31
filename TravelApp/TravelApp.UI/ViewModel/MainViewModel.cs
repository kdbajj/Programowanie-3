using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Model;
using TravelApp.UI.Command;
using TravelApp.UI.Data;

namespace TravelApp.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _searchBox;
        private readonly ITravelAppDataService _travelAppDataService;
        private bool _isDetailsWindowOpen;
        private List<Travel> _travels;

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

                SearchBoxFinder();
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

            _travels = travelsData;
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

        private void SearchBoxFinder()
        {
            if (SearchBox.Length == 0)
            {
                Travels.Clear();

                foreach (var travel in _travels)
                {
                    Travels.Add(travel);
                }

                return;
            }

            var temp = _travels.Where((travel) => travel.City == SearchBox);

            Travels.Clear();
            foreach (var travel in temp)
            {
                Travels.Add(travel);
            }
        }
    }
}
