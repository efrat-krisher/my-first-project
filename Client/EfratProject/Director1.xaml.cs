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
    /// Interaction logic for Director1.xaml
    /// </summary>
    public partial class Director1 : Page
    {
        public Director1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new lstInvitations());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new lstproducts());
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService f = NavigationService.GetNavigationService(this);
        //    f.Navigate(new Director2());
        //}

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new lstCustomer());
        }

        //private void Button_Click_4(object sender, RoutedEventArgs e)
        //{
        //    NavigationService f = NavigationService.GetNavigationService(this);
        //    f.Navigate(new lstKategor());
        //}

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new lstKosher());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new lstCity());
        }

        private void goHome(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Entery());
        }
    }
}
