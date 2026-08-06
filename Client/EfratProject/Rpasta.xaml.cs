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
    /// Interaction logic for Rpasta.xaml
    /// </summary>
    public partial class Rpasta : Page
    {
        public Rpasta()
        {
            InitializeComponent();
        }
        private void Bif(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Rbif());
        }
        private void Haros(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Rharost());
        }

        private void tzli(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Rtzli());
        }

        private void Tavshil(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Rtavshil());
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Recipes());
        }

       
    }
}
