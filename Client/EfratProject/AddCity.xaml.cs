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
    /// Interaction logic for AddCity.xaml
    /// </summary>
    public partial class AddCity : Page
    {
        int status; //קריאה בלבד=3  ,הוספה=1 , עדכון=2 
        Cities C;
        public AddCity()
        {
            InitializeComponent();
            C = new Cities();
            this.DataContext = C;
            status = 1;
        }
        public AddCity(Cities C)
        {
            InitializeComponent();
            this.C = C;
            this.DataContext = C;
            this.status = 2;

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (status == 1) // במצב הוספה
            {
                if (C.CityName == null || C.CityName == "" || C.DayInWeek > 6|| C.DayInWeek ==0 )
                    txtbed.Text = " הכנס נתונים תקינים";
                else
                {
                    if (Global.sharat.AddCity(C))
                    {
                        //Global.CustomerEnter = C;
                        //if (Global.CustomerEnter != null)
                        {
                            txtgood.Text = "נוסף בהצלחה";
                            MessageBox.Show("הפרטים התעדכנו בהצלחה");
                            NavigationService f = NavigationService.GetNavigationService(this);
                            f.Navigate(new Director1());
                        }
                    }
                    else
                        txtbed.Text = "ההוספה נכשלה";
                }
            }
            else
            {
                if (status == 2)//במצב עדכון
                {
                    if (C.CityName == null || C.CityName == "" || C.DayInWeek > 6 || C.DayInWeek <= 0)
                        txtbed.Text = "נא להכניס נתונים תקינים";
                    else
                    {
                        if (Global.sharat.UpdateCity(C))
                        {
                            //Global.CustomerEnter = C;
                            //if (Global.CustomerEnter != null)
                            {
                                //txtgood.Text = "הפרטים התעדכנו בהצלחה";
                                MessageBox.Show("הפרטים התעדכנו בהצלחה");
                            }
                        }
                        else

                            txtbed.Text = "העדכון לא הצליח";
                        NavigationService f = NavigationService.GetNavigationService(this);
                        f.Navigate(new lstCity());
                    }

                }

            }

        }

    }
}
