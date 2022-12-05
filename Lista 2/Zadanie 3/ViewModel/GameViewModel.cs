using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Zadanie_3.Command;
using Zadanie_3.Const;
using Zadanie_3.Model;

namespace Zadanie_3.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        private int _player1Score;
        private int _player2Score;
        private Player _playerTurn;

        public ObservableCollection<Statki> Statki { get; }
        public ObservableCollection<Statki> Statki2 { get; }
        public ObservableCollection<Statki> StatkiShoot { get; }
        public ObservableCollection<Statki> Statki2Shoot { get; }

        public DelegateCommand AddShip { get; }
        public DelegateCommand ShootShip { get; }

        public Player PlayerTurn
        {
            get => _playerTurn;
            private set
            {
                _playerTurn = value;
                OnPropertyChanged();
            }
        }
        public GameViewModel()
        {
            Statki = new ObservableCollection<Statki>();
            StatkiShoot = new ObservableCollection<Statki>();
            Statki2Shoot = new ObservableCollection<Statki>();
            Statki2 = new ObservableCollection<Statki>();


            AddShip = new DelegateCommand(AddShipPosition);
            ShootShip = new DelegateCommand(ShootShipPosition);
            InitBattlefield();
        }

        public int Player1Score
        {
            get => _player1Score;
            set
            {
                _player1Score = value;
                OnPropertyChanged();
            }
        }

        public int Player2Score
        {
            get => _player2Score;
            set
            {
                _player2Score = value;
                OnPropertyChanged();
            }
        }

        private void InitBattlefield()
        {
            const int numberOfButtons = 100;

            for (int i = 0; i < numberOfButtons; i++)
            {
                Statki.Add(new Statki { Player = Player.Player1, Id = i });
            }

            for (int i = 0; i < numberOfButtons; i++)
            {
                Statki2.Add(new Statki { Player = Player.Player2, Id = i });
            }

            for (int i = 0; i < numberOfButtons; i++)
            {
                StatkiShoot.Add(
                    new Statki
                    {
                        Player = Player.Player1,
                        IsShootGood = IsShootGoodEnum.Empty,
                        Id = i
                    });
            }

            for (int i = 0; i < numberOfButtons; i++)
            {
                Statki2Shoot.Add(
                    new Statki
                    {
                        Player = Player.Player2,
                        IsShootGood = IsShootGoodEnum.Empty,
                        Id = i
                    });
            }
        }

        private void AddShipPosition(object obj)
        {
            if (obj is not Statki statki)
            {
                return;
            }


            if (statki.Player == Player.Player1)
            {
                var found = Statki.FirstOrDefault(x => x.Id == statki.Id);
                if (found != null) found.IsShootGood = IsShootGoodEnum.Occupied;
            }
            else
            {
                var found = Statki2.FirstOrDefault(x => x.Id == statki.Id);
                if (found != null) found.IsShootGood = IsShootGoodEnum.Occupied;
            }
        }

        private void ShootShipPosition(object obj)
        {
            if (!(obj is Statki statki))
            {
                return;
            }

            ValidateShoot(statki);
        }

        private void ValidateShoot(Statki statki)
        {

            var found = statki.Player == Player.Player1 ? Statki.FirstOrDefault(x => x.Id == statki.Id) : Statki2.FirstOrDefault(x => x.Id == statki.Id);
            if (found == null)
            {
                return;
            }

            var foundShoot = statki.Player == Player.Player1 ? StatkiShoot.FirstOrDefault(x => x.Id == found.Id) : Statki2Shoot.FirstOrDefault(x => x.Id == found.Id);
            if (foundShoot == null)
            {
                return;
            }

            if (found.IsShootGood != IsShootGoodEnum.Occupied)
            {
                foundShoot.IsShootGood = IsShootGoodEnum.Miss;
                found.IsShootGood = IsShootGoodEnum.Miss;
            }
            else
            {
                foundShoot.IsShootGood = IsShootGoodEnum.Hit;
                found.IsShootGood = IsShootGoodEnum.Hit;
            }
        }
    }
}
