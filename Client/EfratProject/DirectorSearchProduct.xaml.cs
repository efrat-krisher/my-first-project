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
    /// Interaction logic for DirectorSearchProduct.xaml
    /// </summary>
    public partial class DirectorSearchProduct : Page
    {
        List<BlProduct> pro;
        public DirectorSearchProduct()
        {
            InitializeComponent();
        }
        public DirectorSearchProduct(List<BlProduct> l)
        {
            InitializeComponent();
            pro = l;
            Search1.Children.Clear();
            foreach (BlProduct product in pro)
            {
                Search1.Children.Add(new UCproduct(product));
            }

        }
    }
}
