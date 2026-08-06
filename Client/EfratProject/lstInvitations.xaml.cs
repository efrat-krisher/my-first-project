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
    /// Interaction logic for lstInvitations.xaml
    /// </summary>
    public partial class lstInvitations : Page
    {
        public lstInvitations()
        {
            InitializeComponent();
            //LstCity.ItemsSource = Global.sharat.GetCity();         
            //lstInvitations1.ItemsSource = Global.sharat.GetInviting();

        }
        private void ChangeColors(Button b)
        {
            aToday.Background = new SolidColorBrush(Colors.LightGray);
            //aNotPacked.Background = new SolidColorBrush(Colors.LightYellow);
            //aMonth.Background = new SolidColorBrush(Colors.LightYellow);
            aAll.Background = new SolidColorBrush(Colors.LightGray);
            b.Background = new SolidColorBrush(Colors.LightYellow);
        }
        //private void Perut(object sender, RoutedEventArgs e)
        //{
        //    //if (lstInvitations1.SelectedItem != null)
        //    //{
        //    //    NavigationService f = NavigationService.GetNavigationService(this);
        //    //    f.Navigate(new LSTbuy()); // להכניס בסוגריים את הפרוט של ההזמנה אותה הוא שולח 

        //    //}
        //    //     else
        //    //    MessageBox.Show("לא נבחרה הזמנה ");

        //    if (lstInvitations1.SelectedItem != null)
        //    {
        //        Inviting c = lstInvitations1.SelectedItem as Inviting;
        //        NavigationService f = NavigationService.GetNavigationService(this);
        //        f.Navigate(new LSTinvitationsPerut(lstInvitations1.SelectedItem as Inviting));
   
        //    }

        //    else
        //    {
        //        MessageBox.Show("לא נבחרה הזמנה ");
        //    }

        //}

        //private void Today(object sender, RoutedEventArgs e)
        //{
        //    lstInvitations1.ItemsSource = Global.sharat.GetInvitings().Where(a => a.dateBuy <= DateTime.Today && a.sent == false  );
        //}

        //private void NotPacked(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Month(object sender, RoutedEventArgs e)
        //{

        //}

        private void All(object sender, RoutedEventArgs e)
        {
            f2.Navigate(new lstInvitationsALL());
        }

        //private void It(object sender, RoutedEventArgs e)
        //{
        //    Cities c = LstCity.SelectedItem as Cities;
        //    txtCity.Text = c.CityName;
        //    x.Visibility = Visibility.Visible;
        //}

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    x.Visibility = Visibility.Collapsed;
        //}

        //private void LstCity_SelectionChanged(object sender, SelectionChangedEventArgs e)

        //{
        //    Cities c1 = LstCity.SelectedItem as Cities;
        //    txtCity.Text = c1.CityName;
        //    x.Visibility = Visibility.Visible;
        //    Cities c = LstCity.SelectedItem as Cities;
        //    lstInvitations1.ItemsSource = Global.sharat.GetOrdersByCity(c.CityCode);
        //}

        private void City(object sender, RoutedEventArgs e)
        {
            f2.Navigate(new lstInvitationsCity());
        }

        private void Today(object sender, RoutedEventArgs e)
        {
            f2.Navigate(new lstInvitationsToday());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Director1());
        }
    }
}
