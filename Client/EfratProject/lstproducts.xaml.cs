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
    /// Interaction logic for lstproducts.xaml
    /// </summary>
    public partial class lstproducts : Page
    {
        List<BlProduct> productsList = new List<BlProduct>();
        public lstproducts()
        {
            InitializeComponent();
            lstInvitations.ItemsSource = Global.sharat.GetProducts();
        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new AddNewProduct()); //להוסיף שישלח את המוצר
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (lstInvitations.SelectedItem != null)
            {
                BlProduct p = lstInvitations.SelectedItem as BlProduct;
                Global.sharat.deleteproduct(p);
                //טעינה מחדש של הרשימה
                lstInvitations.ItemsSource = Global.sharat.GetProducts();
                MessageBox.Show("המחיקה הצליחה");
            }
            else
                MessageBox.Show("לא נבחר פריט למחיקה");

        }


        private void UpdateProduct(object sender, RoutedEventArgs e)
        {  
            NavigationService nav = NavigationService.GetNavigationService(this);          
            nav.Navigate(new AddNewProduct()); 
            //nav.Navigate(new AddNewProduct(Global.sharat.UpdateProduct()));
            //nav.Navigate(new NewCustomer(Global.CustomerEnter));
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productsList != null)
            {

                productsList = Global.sharat.SearchProducts(search.Text);
                if (search.Text != "")
                {
                    f2.Navigate(new DirectorSearchProduct(productsList));
                }
            }
        }

        private void goHome(object sender, RoutedEventArgs e)
        {
            //NavigationService f = NavigationService.GetNavigationService(this);
            //f.Navigate(new Entery());
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Director1());
        }
    }

}
