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

namespace Exercise1
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

        private void Calculate(object sender, RoutedEventArgs e)
        {
                label_Name.Content = txtbox_Name.Text;
                label_Addy.Content = txtbox_Addy.Text;
            int price = 0;
            if (flossing.IsChecked == true)
            {
                price += 20;
                if (Kid.IsChecked == true)
                {
                    label_Total.Content = (price - price * 15 / 100).ToString();
                }
                if (Senior.IsChecked == true)
                {
                    label_Total.Content = (price - price * 10 / 100).ToString();
                }
                if (Adult.IsChecked == true)
                {
                    label_Total.Content = price.ToString();
                }
            }
            if (filling.IsChecked == true)
            {
                price += 75;
                if (Kid.IsChecked == true)
                {
                    label_Total.Content = (price - price * 15 / 100).ToString();
                }
                if (Senior.IsChecked == true)
                {
                    label_Total.Content = (price - price * 10 / 100).ToString();
                }
                if (Adult.IsChecked == true)
                {
                    label_Total.Content = price.ToString();
                }
            }
            if (root.IsChecked == true)
            {
                price += 150;
                if (Kid.IsChecked == true)
                {
                   label_Total.Content = (price - price * 15 / 100).ToString();
                }
                if (Senior.IsChecked == true)
                {
                    label_Total.Content = (price - price * 10 / 100).ToString();
                }
                if (Adult.IsChecked == true)
                {
                    label_Total.Content = price.ToString();
                }
            }

        }

        private void radio_Aduult(object sender, RoutedEventArgs e)
        {
           
        }

        private void radio_senior(object sender, RoutedEventArgs e)
        {

        }

        private void radio_Kid(object sender, RoutedEventArgs e)
        {
            int value = 15;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
