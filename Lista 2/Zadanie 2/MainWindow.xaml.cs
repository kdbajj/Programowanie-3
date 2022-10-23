using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Zadanie_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            TicTacToe();
        }
        #endregion


        #region Private Members

        /// <summary>
        /// Holds current results of cells in active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player 1's turn (o) or player 2 (x)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        ///  True if game has ended
        /// </summary>
        private bool mGameEnded;

        /// <summary>
        /// Starts a new game and clears all values back to the starts
        /// </summary>
        private void TicTacToe()
        {
            //Create new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }
            // Player 1 starts the game
            mPlayer1Turn = true;

            // Interate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                //Change background and foreground to default values
                button.Content = string.Empty;
                SolidColorBrush myBrush = new SolidColorBrush(color: Color.FromRgb(239, 206, 250));
                button.Background = myBrush;


            });

            mGameEnded = false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                TicTacToe();
                return;
            }
            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            if (mResults[index] != MarkType.Free)
                return;


            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1Turn ? "O" : "X";

            //Change noughts to pink

            if (!mPlayer1Turn)
                button.Foreground = Brushes.Purple;
            mPlayer1Turn ^= true;
            CheckForWinner();
        }

        private void CheckForWinner()
        {

            //Horizontal Wins

            //Row 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.White;
            }
            

                //Row 1
                if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
                {
                    mGameEnded = true;

                    Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.White;
                }
                
                    //Row 2
                    if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
                    {
                        mGameEnded = true;

                        Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.White;
                    }
                   
                        //Checks for vertical wins
                        //Column 0
      if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
     {
         mGameEnded = true;

         Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.White;
     }
    
             //Column 1
     if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
     {
         mGameEnded = true;

         Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.White;
     }

     //Column 2
     if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
     {
         mGameEnded = true;

         Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.White;
     }
            //Diagonal wins

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.White;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.White;
            }


            if (!mResults.Any(result => result == MarkType.Free))
        {
            mGameEnded = true;
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Background = Brushes.White;

            });
        }
       }
      }
     }  
    
   
 
 


#endregion