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
    /// Interaction logic for LSTinvitationsPerut.xaml
    /// </summary>
    public partial class LSTinvitationsPerut : Page
    {
        List<hazmana> h = new List<hazmana>();
       Inviting I;
        public LSTinvitationsPerut()
        {
            InitializeComponent();
        }
          public LSTinvitationsPerut(Inviting i)
        {
            InitializeComponent();
            I = i;
            if (Global.CustomerEnter == null)
            {
                arr.Visibility = Visibility.Visible;
            }
            //h.Clear();
            h = Global.sharat.GetItemsinOrder().Where(a=> a.inviting.HazmanaCode == I.HazmanaCode).ToList();
            lstbuy.ItemsSource = h;
            Pay.Text = I.filnalPrice.ToString();
        }

        private void DidntArrived(object sender, RoutedEventArgs e)
        {
            if (lstbuy.SelectedItem != null)
            {
                hazmana h = lstbuy.SelectedItem as hazmana;
                if (h.sent == true)
                {
                    h.sent = false;
                    Global.sharat.RemoveProductFromInvite(h);
                    NavigationService f = NavigationService.GetNavigationService(this);
                    f.Navigate(new LSTinvitationsPerut(I as Inviting));
                    I.filnalPrice -= h.product.price;
                    Pay.Text=  I.filnalPrice.ToString();
                    MessageBox.Show(h.product.ProductName + " נמחק מהרשימה ");
                }
            }
            else
            {
                MessageBox.Show("לא נבחר מוצר מהרשימה");
            }

        }

        private void quit(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.GoBack();
        }
    }
}
