using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
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
            OpenBasketWindowCommand = new DelegateCommand(OpenBasketWindow);


        }

        private async void UpdateImage()
        {
            BitmapImage image;

            //OpenFileDialog op = new OpenFileDialog();
            //op.Title = "Select a picture";
            //op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            //            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            //            "Portable Network Graphic (*.png)|*.png";
            //if (op.ShowDialog() == true)
            //{
            //    image = new BitmapImage(new Uri(op.FileName));
            //}
            //else
            //{
            //    return;
            //}

            image = new BitmapImage(new Uri(
                @"C:\Users\kdbaj\Desktop\repos\programowanie-3\TravelApp\TravelApp.UI\Assets\Images\Travelmages\oslo.jpg"));

            byte[] streamByte;

            using (var stream = new MemoryStream())
            {
                var encoder = new JpegBitmapEncoder(); // or some other encoder
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                streamByte = stream.ToArray();
            }

            var travel = Travels[4];
            travel.TravelImage = streamByte;
            await _travelAppDataService.UpdateTravel(travel);
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
        public DelegateCommand OpenBasketWindowCommand { get; set; }

        public async Task OnLoad()
        {
            var travelsData = await _travelAppDataService.GetAll();

            Travels.Clear();

            foreach (var travel in travelsData)
            {
                Travels.Add(travel);
            }

            _travels = travelsData;

            //UpdateImage();

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
        private void OpenBasketWindow(object? obj)
        {
            var newWindow = new BasketWindow();
            var basketViewModel = new BasketViewModel();

            newWindow.DataContext = basketViewModel;
            newWindow.Show();
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
