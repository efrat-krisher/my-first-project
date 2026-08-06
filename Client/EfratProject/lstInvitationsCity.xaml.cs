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
    /// Interaction logic for lstInvitationsCity.xaml
    /// </summary>
    public partial class lstInvitationsCity : Page
    {
        public lstInvitationsCity()
        {
            InitializeComponent();
            LstCity.ItemsSource = Global.sharat.GetCity();
            //lstInvitations1.ItemsSource = Global.sharat.GetInviting();
        }
        private void LstCity_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            Cities c1 = LstCity.SelectedItem as Cities;
            txtCity.Text = c1.CityName;
            x.Visibility = Visibility.Visible;
            Cities c = LstCity.SelectedItem as Cities;
            lstInvitations1.ItemsSource = Global.sharat.GetOrdersByCity(c.CityCode);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            x.Visibility = Visibility.Collapsed;
        }

        private void Perut(object sender, RoutedEventArgs e)
        {
            if (lstInvitations1.SelectedItem != null)
            {
                Inviting c = lstInvitations1.SelectedItem as Inviting;
                NavigationService f = NavigationService.GetNavigationService(this);
                f.Navigate(new LSTinvitationsPerut(lstInvitations1.SelectedItem as Inviting));

            }

            else
            {
                MessageBox.Show("לא נבחרה הזמנה ");
            }
        }

        private void Dlete(object sender, RoutedEventArgs e)
        {
            if (lstInvitations1.SelectedItem != null)
            {
                Inviting inv = lstInvitations1.SelectedItem as Inviting;
                Global.sharat.deleteHazmana(inv);
                //טעינה מחדש של הרשימה
                lstInvitations1.ItemsSource = Global.sharat.GetInviting();
                MessageBox.Show("המחיקה הצליחה");
            }
            else
                MessageBox.Show("לא נבחר פריט למחיקה");
        }
    }
}
