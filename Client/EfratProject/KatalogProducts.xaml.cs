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
    /// Interaction logic for KatalogProducts.xaml
    /// </summary>
    public partial class KatalogProducts : Page
    {
        public KatalogProducts()
        {
            InitializeComponent();
            //txtKatalogPro.Text = Global.sharat.GetKategor.KategorName;
        }
    }
}
