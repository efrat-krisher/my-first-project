using EfratProject.ServiceReference2;
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

namespace EfratProject
{
    /// <summary>
    /// Interaction logic  for NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Page 
     {    
       int status; //קריאה בלבד=3  ,הוספה=1 , עדכון=2 
   
        customers C;
        public NewCustomer()
        {
            InitializeComponent();
            C=new customers();
            this.DataContext = C;
            cmCity.ItemsSource = Global.sharat.GetCity();
            status=1;
        }
        public NewCustomer(customers c)
        {
            InitializeComponent();
            this.C=c;
            this.DataContext = c;
            this.status = 2;
            cmCity.ItemsSource = Global.sharat.GetCity();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (status == 1) // במצב הוספה
            {

                if (C.phone == null || C.phone == "" || C.FirstName == null || C.FirstName == "" || C.LastName == null || C.LastName == "" || C.adress == null || C.adress == ""
                  || C.apartment == null || C.apartment == "" || C.floor == null || C.floor == ""  )
                    txtbed.Text = " הכנס נתונים תקינים";
                else
                {
                    if (Global.sharat.AddCustomers(C))
                    {
                        //לשנות שהלקוח בגלובל יקבל מפעולה בשרת את הלקוח שנוסף אחרון עם אותו שם
                        Global.CustomerEnter = C;
                        Global.recepit = new List<hazmana>();
                        if (Global.CustomerEnter!=null)
                        { 
                            //txtgood.Text = "   נוספת בהצלחה , הכנס ללקוח קיים לביצוע ההזמנה הראשונה";
                            MessageBox.Show("פרטיך נשמרו בהצלחה , הכנס ללקוח קיים לביצוע ההזמנה הראשונה");
                            NavigationService f = NavigationService.GetNavigationService(this);
                             f.Navigate(new Entery());
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
                    if (C.phone == null || C.phone == "" || C.FirstName == null || C.FirstName == "" || C.LastName == null || C.LastName == "" || C.adress == null || C.adress == ""
                  || C.apartment == null || C.apartment == "" || C.floor == null || C.floor == "" || C.floor == null || C.floor == "")
                        txtbed.Text = "נא להכניס נתונים תקינים";
                    else
                    {
                        if (Global.sharat.UpdateCustomer(C))
                        {
                            Global.CustomerEnter = C;
                            if (Global.CustomerEnter != null)
                            {
                                txtgood.Text = "הפרטים התעדכנו בהצלחה";
                            }
                        }
                        else

                            txtbed.Text = "העדכון לא הצליח";
                    }

                }

            }

        }


  
    }
}
