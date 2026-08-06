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
    /// Interaction logic for Entery.xaml
    /// </summary>
    public partial class Entery : Page
    {
        public Entery()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Director());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new NewCustomer());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)

        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new OldCustomer());
        }
    }
}
