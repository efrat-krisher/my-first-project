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
    /// Interaction logic for lstInvitationsToday.xaml
    /// </summary>
    public partial class lstInvitationsToday : Page
    {
        public lstInvitationsToday()
        {
            InitializeComponent();          
            lstInvitations1.ItemsSource = Global.sharat.GetOrdersByDay();
            //lstInvitations1.ItemsSource = Global.sharat.GetInviting();
            txtDay.Text = DateTime.Today.DayOfWeek+"  "+DateTime.Today.Day+"/"+ DateTime.Today.Month+"/"+ DateTime.Today.Year; 
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
    }
}
