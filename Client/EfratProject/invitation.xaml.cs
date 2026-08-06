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
    /// Interaction logic for invitation.xaml
    /// </summary>
    public partial class invitation : Page
    {
        public invitation()
        {
            InitializeComponent();
            txtnamecustomerenter.Text = Global.CustomerEnter.FirstName;          
            txtnamecustomerenter1.Text = Global.CustomerEnter.LastName;//   כותב שלום ל"פלוני/ת" ושולף מטבלת הלקוחות 
            txtnamecity.Text = Global.CustomerEnter.city1.CityName;
            //txtDay.Text = Global.CustomerEnter.city1.DayInWeek.ToString();//להמיר ממספר יום לטקסט  
            int x = Global.CustomerEnter.city1.DayInWeek ; // הופך מספר יום לשמו 
            if (x == 1)
                txtDay.Text = "ראשון";
            else if (x == 2)
                txtDay.Text = "שני";
            else if (x == 3)
                txtDay.Text = "שלישי";
            else if (x == 4)
                txtDay.Text = "רביעי";
            else if (x == 5)
                txtDay.Text = "חמישי";
            else
                txtDay.Text = " ";
        }


        private void sal(object sender, RoutedEventArgs e)
        {   NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new LSTbuy());
           
            //f.Navigate(new sal());
        }

        private void ishi(object sender, RoutedEventArgs e)
        {
            
            f1.Navigate(new CustomerIshi());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           f1.Navigate(new MenuePage());
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);
            f.Navigate(new Entery());
        }

        private void about(object sender, RoutedEventArgs e)
        {
          
            f1.Navigate(new about());
        }
      

        private void Deliver(object sender, RoutedEventArgs e)
        {
           
            f1.Navigate(new Distribution_times());
            

        }

        private void AnsQ(object sender, RoutedEventArgs e)
        {

        }

        private void Rec(object sender, RoutedEventArgs e)
        {
            f1.Navigate(new Recipes());
        }

       
    }
}
