using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zadanie_3.ViewModel;

namespace Zadanie_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            var _gameViewModel = new GameViewModel();

            this.DataContext = _gameViewModel;

            Window2 window2 = new Window2();
            window2.DataContext = _gameViewModel;
            window2.Show();
        }
    }
}
