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
    /// Interaction logic for Finish.xaml
    /// </summary>
    public partial class Finish : Page
    {
        public Finish()
        {
            InitializeComponent();
        }

        private void finishhh(object sender, RoutedEventArgs e)
        {
           Inviting inviting = new Inviting();
            inviting.Customer = Global.CustomerEnter;
            inviting.dateBuy = DateTime.Today;
            //inviting.dateBuy = DateTime.Now;
            DateTime dt = DateTime.Today;
            while(((int)dt.DayOfWeek)!=Global.CustomerEnter.city1.DayInWeek)
                dt = dt.AddDays(1);
            inviting.dateSent = dt;
            inviting.filnalPrice=Global.recepit.Sum(x=>x.product.price*x.Amount);
            inviting.sent = false;
            Global.sharat.CreateOrder(inviting, Global.recepit);
            MessageBox.Show("ההזמנה התקבלה בהצלחה");
            //NavigationService f = NavigationService.GetNavigationService(this);
            //f.Navigate(new Entery());
        }

     
    }
}
