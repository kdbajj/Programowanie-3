using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zadanie_3.Const;

namespace Zadanie_3.Model
{
    public class Statki : INotifyPropertyChanged
    {
        private IsShootGoodEnum _isShootGood;

        public  Player Player { get; set; }
        public IsShootGoodEnum IsShootGood
        {
            get => _isShootGood;
            set
            {
                _isShootGood = value;
                OnPropertyChanged();
            }
        }

        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
