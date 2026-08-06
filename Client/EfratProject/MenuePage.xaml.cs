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
    
    public partial class MenuePage : Page
    {
        AllBasarK BK;
        AllBasarT BT;
        AllOfot OT;
        AllOfotK OK;

        List<BlProduct> productslist;
        public MenuePage()
        {
            InitializeComponent();
        }
        private void ChangeColors(Button b)
        {
            AOfotK.Background = new SolidColorBrush(Colors.LightYellow);
            ABasarT.Background = new SolidColorBrush(Colors.LightYellow);
            AOfotT.Background = new SolidColorBrush(Colors.LightYellow);
            ABasarK.Background = new SolidColorBrush(Colors.LightYellow);
            b.Background = new SolidColorBrush(Colors.LightGray);
        }



        private void OfotK(object sender, RoutedEventArgs e)
        {
            if(OK == null)
            {
                OK=new AllOfotK();
            }

            f2.Navigate(OK);
            ChangeColors(AOfotK);
        }

        private void BasarK(object sender, RoutedEventArgs e)
        {
            if (BK == null)
            {
                BK=new AllBasarK();
            }
            f2.Navigate(BK);
            ChangeColors(ABasarK);
        }

        private void OfotT(object sender, RoutedEventArgs e)
        {
            if(OT == null)
            {
                OT = new AllOfot();
            }
            f2.Navigate(OT);
            ChangeColors(AOfotT);
        }

        private void BasarT(object sender, RoutedEventArgs e)
        {
            if(BT == null)
            {
                BT = new AllBasarT();
            }
            f2.Navigate(BT);
            ChangeColors(ABasarT);
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productslist != null)
            {

                productslist = Global.sharat.SearchProducts(search.Text);
                if (search.Text != "")
                {
                    f2.Navigate(new DirectorSearchProduct(productslist));
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{

        //    MyBasket.Text = Global.Sum.ToString();
        //}
    }
}
