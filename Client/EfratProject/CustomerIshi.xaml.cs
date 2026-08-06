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

namespace EfratProject
{
    /// <summary>
    /// Interaction logic for CustomerIshi.xaml
    /// </summary>
    public partial class CustomerIshi : Page
    {
        public CustomerIshi()
        {
            InitializeComponent();
        }

        private void ChangeDetail(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new NewCustomer(Global.CustomerEnter));
        }

        //private void OldBuy(object sender, RoutedEventArgs e)
        //{

        //}

     

        //private void goHome(object sender, RoutedEventArgs e)
        //{
        //    NavigationService f = NavigationService.GetNavigationService(this);  // עשיתי בפריים- לא צריך
        //    f.Navigate(new Entery());
        //}
    }
}
