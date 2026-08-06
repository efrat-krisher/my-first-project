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
    /// Interaction logic for Pay.xaml
    /// </summary>
    public partial class Pay : Page
    {
        public Pay()
        {
            InitializeComponent();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            NavigationService f = NavigationService.GetNavigationService(this);

            switch (cmA.Text)
            {
                case "אשראי":
                    f2.Navigate(new PayByCard());
                    break;
                case "שיק":
                    f2.Navigate(new Finish());
                    break;
                case "מזומן":
                    f2.Navigate(new Finish());
                    break;
            }


        
        }
    }
}
