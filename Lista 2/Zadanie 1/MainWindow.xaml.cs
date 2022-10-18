using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

namespace Zadanie_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ResultLabel.Text = string.Empty;
            CurrentOperation.Text =string.Empty;
        }

        private void NumberEvent_Button(object sender, RoutedEventArgs e)
        {
            ResultLabel.Text = string.Empty;

            var Button = sender as Button;

            var currentNumber = Button.Name[Button.Name.Length-1];

            CurrentOperation.Text += currentNumber;
        }

        private void buttonEqual_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperation.Text;

           ResultLabel.Text = CalculateResult(operation).ToString();

            CurrentOperation.Text = string.Empty;
        }

        

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperation.Text;
            if (ContainsOperation(operation))
            {
                CurrentOperation.Text = CalculateResult(operation).ToString();
            }

            CurrentOperation.Text += "+";

        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperation.Text;
            if (ContainsOperation(operation))
            {
                CurrentOperation.Text = CalculateResult(operation).ToString();
            }

            CurrentOperation.Text += "-";

        }

        private void buttonMultiply_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperation.Text;
            if (ContainsOperation(operation))
            {
                CurrentOperation.Text = CalculateResult(operation).ToString();
            }
            CurrentOperation.Text += "*";

        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperation.Text;
            if (ContainsOperation(operation))
            {
                CurrentOperation.Text = CalculateResult(operation).ToString();
            }
            CurrentOperation.Text += "/";

        }

        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            var output = "";
            ResultLabel.Text = output;
        }

        private bool ContainsOperation(string operation)=> operation.Contains('*') || operation.Contains('/') || operation.Contains('+') || operation.Contains('-');

        

        private int CalculateResult(string operation)
        {
            if (operation.Contains('+'))
            {
                var elements = operation.Split('+');

               return int.Parse(elements[0]) + int.Parse(elements[1]);
            }

            if (operation.Contains('-'))
            {
                var elements = operation.Split('-');

                return int.Parse(elements[0]) - int.Parse(elements[1]);
            }

            if (operation.Contains('/'))
            {
                var elements = operation.Split('/');

                return int.Parse(elements[0]) / int.Parse(elements[1]);
                
            }

            if (operation.Contains('*'))
            {
                var elements = operation.Split('*');

                return int.Parse(elements[0]) * int.Parse(elements[1]);
            }

            return default;
        }
    }
}
