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
    /// Interaction logic for PayByCard.xaml
    /// </summary>
    public partial class PayByCard : Page
    {
        public PayByCard()
        {
            InitializeComponent();
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            ADD.Visibility = Visibility.Collapsed;
            f.Navigate(new Finish());
        }
    }
}
