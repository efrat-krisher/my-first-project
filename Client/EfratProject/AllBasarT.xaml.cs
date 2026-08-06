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
    /// Interaction logic for AllBasar.xaml
    /// </summary>
    public partial class AllBasarT : Page
    {
        List<BlProduct> pbT;
        public AllBasarT()
        {
            InitializeComponent();
            // מקבלת מהשרת את הרשימה שאותה אני רוצה להציג
            pbT = Global.sharat.GetProducts().ToList();
            // עוברת על הרשימה ועבור כל  אחד מייצרת יוזר קונטרול ומוסיפה
            //foreach (BlProduct product in pb)
            //{  
            //    Basar.Children.Add(new UCproduct(this, product));
            //}
        }   
    }
}
