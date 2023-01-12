using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
