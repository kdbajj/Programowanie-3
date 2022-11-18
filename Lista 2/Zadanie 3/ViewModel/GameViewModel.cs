using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie_3.Model;

namespace Zadanie_3.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        private int _player1Score;
        private int _player2Score;
        public ObservableCollection<Statki> Statki { get; }
        public ObservableCollection<Statki> Statki2 { get; }

        public GameViewModel()
        {
            Statki = new ObservableCollection<Statki>();

            for(int i = 0; i < 100; i++)
            {
                Statki.Add(new Statki() { Player=1});
            }

            Statki2 = new ObservableCollection<Statki>();
            for (int i = 0; i < 100; i++)
            {
                Statki2.Add(new Statki() { Player = 1 });
            }


        }

        public int Player1Score
        {
            get => _player1Score;
            set
            {
                _player1Score = value;
                OnPropoertyChange();
            }
        }

        public int Player2Score
        {
            get => _player2Score;
            set
            {
                _player2Score = value;
                OnPropoertyChange();
            }
        }
    }
}
