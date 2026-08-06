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
    /// Interaction logic for AddKosher.xaml
    /// </summary>
    public partial class AddKosher : Page
    {
        int status; //קריאה בלבד=3  ,הוספה=1 , עדכון=2 
        kosher kosh;
        public AddKosher()
        {
            InitializeComponent();
            kosh = new kosher();
            this.DataContext = kosh;
            status = 1;
        }
       
  
        public AddKosher(kosher kosh)
        {
            InitializeComponent();
            this.kosh = kosh;
            this.DataContext = kosh;
            this.status = 2;

        }
        private void AddPicture(object sender, RoutedEventArgs e)
        {
            string fileName = MyImages.UploadImage_Dlg();
            if (fileName != null)
            {
                //kosh.KosherPicture = fileName;
                image1.Source = MyImages.GetImage(fileName);/*new BitmapImage(new Uri(fileName));*/// MyImages.GetImage( fileName);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (status == 1) // במצב הוספה
            {
                if (kosh.KosherName == null || kosh.KosherName == "" )
                    txtbed.Text = " הכנס נתונים תקינים";
                else
                {
                    if (Global.sharat.AddKosher(kosh))
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
                    if (kosh.KosherName == null || kosh.KosherName == "")
                        txtbed.Text = "נא להכניס נתונים תקינים";
                    else
                    {
                        if (Global.sharat.UpdateKosher(kosh))
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
                    }

                }

            }

        }
    }

        
    
}
