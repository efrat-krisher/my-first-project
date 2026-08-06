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
    /// Interaction logic for lstCustomer.xaml
    /// </summary>
    public partial class lstCustomer : Page
    {
        public lstCustomer()
        {
            InitializeComponent();
            lstCustomers.ItemsSource = Global.sharat.GetCustomers();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lstCustomers.SelectedItem != null)
            {
                customers c = lstCustomers.SelectedItem as customers;
                Global.sharat.deleteCustomer(c);
                //טעינה מחדש של הרשימה
                lstCustomers.ItemsSource = Global.sharat.GetCustomers();
                MessageBox.Show("המחיקה הצליחה");
            }
            else
                MessageBox.Show("לא נבחר פריט למחיקה");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Director1());
        }
    }
}
