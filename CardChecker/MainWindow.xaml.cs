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

namespace CardChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static long CardNumber;
        private static int Sum;
        private static int DigitBeingChecked;
        private const int CardNumberLength = 16;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void EnterButtonClicked(object sender, RoutedEventArgs e)
        {
            Sum = 0;
            if (CardNumberEntryBox.Text.Length == CardNumberLength)
            {
                CardNumber = Convert.ToInt64(CardNumberEntryBox.Text);
                CheckDigits();
            }
        }
        private void CheckDigits()
        {
            for (int i = 0; i < CardNumberLength - 1; i++)
            {
                DigitBeingChecked = CardNumber.ToString()[i] - 48;
                if (i % 2 == 0)
                {
                    Sum += DoubleDigit(DigitBeingChecked);
                }
                else
                {
                    Sum += DigitBeingChecked;
                }
            }
            CheckSum();
        }
        private static int DoubleDigit(int Digit)
        {
            Digit *= 2;

            if (Digit > 10)
            {
                Digit = 1 + (Digit % 10);
            }
            return Digit;
        }
        private bool CheckSum()
        {
            if ((Sum + (CardNumber % 1000000000000000)) % 10 == 0)
            {
                CardNumberEntryBox.Background = Brushes.Green;
                return true;
            }
            else
            {
                CardNumberEntryBox.Background = Brushes.Red;
                return false;
            }
        }
    }
}
