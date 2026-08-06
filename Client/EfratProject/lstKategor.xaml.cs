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
    /// Interaction logic for lstKategor.xaml
    /// </summary>
    public partial class lstKategor : Page
    {
        public lstKategor()
        {
            InitializeComponent();
            LstKategor.ItemsSource = Global.sharat.GetKategor();
        }

        private void NewKategor(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new AddKategor());
        }

        private void Back(object sender, RoutedEventArgs e)
        {

            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Director1());
        }
    }

}
