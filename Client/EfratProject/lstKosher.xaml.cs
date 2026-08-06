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
    /// Interaction logic for lstKosher.xaml
    /// </summary>
    public partial class lstKosher : Page
    {
        public lstKosher()
        {
            InitializeComponent();
            LstKosher.ItemsSource = Global.sharat.GetKosher();
        }

        private void NewKosher(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new AddKosher());
        }
     

        private void DeleteKosher(object sender, RoutedEventArgs e)
        {
            if (LstKosher.SelectedItem != null)
            {
                kosher kosh = LstKosher.SelectedItem as kosher;
                Global.sharat.deleteKosher(kosh);
                //טעינה מחדש של הרשימה
                LstKosher.ItemsSource = Global.sharat.GetKosher();
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
