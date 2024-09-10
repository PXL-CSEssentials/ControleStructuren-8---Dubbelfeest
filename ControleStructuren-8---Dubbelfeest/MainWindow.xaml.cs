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

namespace ControleStructuren_8___Dubbelfeest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            int numberOfPersons;
            bool isNumber = int.TryParse(numberOfPersonsTextBox.Text, out numberOfPersons);
            if (!isNumber || numberOfPersons < 2)
            {
                return;
            }

            const int NumberOfDaysInYear = 365;
            int counter = NumberOfDaysInYear - 1;
            float chanceOnDifferentDay = 1.0f;

            for (int i = 2; i <= numberOfPersons; i++)
            {
                chanceOnDifferentDay *= (counter / (float)NumberOfDaysInYear);
                counter--;
            }
            chanceOnDifferentDay *= 100;

            float chanceOnSameDay = 100 - chanceOnDifferentDay;
            resultTextBox.Text = $"De kans op gelijke verjaardagen is {chanceOnSameDay:f2}%";

            numberOfPersonsTextBox.Focus();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            numberOfPersonsTextBox.Clear();
            resultTextBox.Clear();
            numberOfPersonsTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
