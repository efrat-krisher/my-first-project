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
    /// Interaction logic for LSTbuy.xaml
    /// </summary>
    public partial class LSTbuy : Page
    {

        double sum = 0;
        int i = 0;        
        //int stat = 0;
        public LSTbuy()
        {
            InitializeComponent();
            lstbuy.ItemsSource = Global.recepit;
            sum = Global.recepit.Sum(x => x.product.price * x.Amount);
            Pay.Text = sum.ToString();
            //NumProducts.Visibility = Visibility.Collapsed;
            //stat = 1;//הוספת הזמנה   
        }
    


        private void finishInvite(object sender, RoutedEventArgs e)
        {
            //Inviting i = lstbuy.SelectedItems as Inviting;
            //i.filnalPrice = sum;
            //if (i .filnalPrice >=500)
            //{
            if(sum>=500)
            {
               NavigationService f = NavigationService.GetNavigationService(this);
                f.Navigate(new Pay());
            }                          
            else
              MessageBox.Show("סכום הקניה מתחת ל500 , הוסף עוד מוצרים או שלם 20 שח עבור המשלוח");
            r.Visibility = Visibility.Visible;
        }

        private void Delit(object sender, RoutedEventArgs e)
        {
            if (lstbuy.SelectedItem != null)
            {
                hazmana c = lstbuy.SelectedItem as hazmana;
                Global.recepit.Remove(c as hazmana);
                //Global.sharat.RemoveProductFromInvite(c);
                //lstbuy.ItemsSource = Global.sharat.GetInvitingDetails();
                MessageBox.Show(c.product.ProductName + " נמחק מהרשימה ");
                NavigationService f = NavigationService.GetNavigationService(this);
                f.Navigate(new LSTbuy()); ;
             
                i = 0;
                foreach (hazmana item in Global.recepit)
                {
                    i++;
                    NumProducts.Text = i.ToString();
                }
               
            }
            else
                MessageBox.Show("לא נבחר פריט למחיקה");
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //if (stat == 1)
            //{
                foreach (hazmana item in Global.recepit)
                {
                    i++;
                    // double nam = item.price;  
                    //sum += nam;
                    
                }
                Pay.Text = sum.ToString();
                NumProducts.Text = i.ToString();
            //}
        }

        private void plus20(object sender, RoutedEventArgs e)
        {
            sum += 20;
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Pay());

        }
    }
}
