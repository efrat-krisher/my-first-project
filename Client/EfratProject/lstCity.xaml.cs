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
using EfratProject.ServiceReference2;

namespace EfratProject
{
    /// <summary>
    /// Interaction logic for lstCity.xaml
    /// </summary>
    public partial class lstCity : Page
    {
        public lstCity()
        {
            InitializeComponent();
            LstCity.ItemsSource = Global.sharat.GetCity();
        }

        private void NewCity(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new AddCity());
        }

        private void DeleteCity(object sender, RoutedEventArgs e)
        {
            if (LstCity.SelectedItem != null)
            {
               Cities c = LstCity.SelectedItem as Cities;
                Global.sharat.deleteCity(c);
                //טעינה מחדש של הרשימה
                LstCity.ItemsSource = Global.sharat.GetCity();
                MessageBox.Show("המחיקה הצליחה");
            }
            else
                MessageBox.Show("לא נבחר פריט למחיקה");

        }

        private void updateCity(object sender, RoutedEventArgs e)
        {
            Cities c = LstCity.SelectedItem as Cities;
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AddCity(c));
        }

        private void GoHome(object sender, RoutedEventArgs e) // חזרה לעמוד ראשי
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Director1());
            //NavigationService f = NavigationService.GetNavigationService(this);
            //f.Navigate(new Entery());
        }
    }
}
