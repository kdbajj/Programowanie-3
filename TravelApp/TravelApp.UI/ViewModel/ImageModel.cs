using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TravelApp.UI.ViewModel
{
    internal class ImageModel
    {
        public ObservableCollection<ImageModel> Images = new ObservableCollection<ImageModel>();
        public string Path { get; set; }
        public string Title { get; set; }

    }
}
