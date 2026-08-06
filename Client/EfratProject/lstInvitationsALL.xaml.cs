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
    /// Interaction logic for lstInvitationsALL.xaml
    /// </summary>
    public partial class lstInvitationsALL : Page
    {
        public lstInvitationsALL()
        {
            InitializeComponent();
            lstInvitations1.ItemsSource = Global.sharat.GetInviting();
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
