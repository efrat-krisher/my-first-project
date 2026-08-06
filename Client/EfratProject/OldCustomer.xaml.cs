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
    /// Interaction logic for OldCustomer.xaml
    /// </summary>
    public partial class OldCustomer : Page
    {
        public OldCustomer()
        {
            InitializeComponent();
            tx.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Global.recepit = new List<hazmana>();
            customers u = Global.sharat.GetCustomerByPhone(tx.Text);
            if (u != null)//אם 
            {
                Global.CustomerEnter = u;
                NavigationService f = NavigationService.GetNavigationService(this);
                f.Navigate(new invitation());
            }
            else
            {
                MessageBox.Show("מספר הטלפון אינו קיים כלקוח");
            }

        }

    }
}
