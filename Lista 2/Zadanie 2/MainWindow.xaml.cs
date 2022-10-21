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

            for(var i = 0; i < mResults.Length; i++)
            {
                mResults[i] =MarkType.Free;
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
               button.Foreground = myBrush;
               
           });
            
            mGameEnded = false;

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
#endregion