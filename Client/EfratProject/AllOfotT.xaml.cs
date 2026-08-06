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
    /// Interaction logic for AllOfot.xaml
    /// </summary>
    public partial class AllOfot : Page

    {
        List<BlProduct> po;
        List<BlProduct> productsList = new List<BlProduct>();
        public AllOfot()
        {
            InitializeComponent();
            // מקבלת מהשרת את הרשימה שאותה אני רוצה להציג
            po =Global.sharat.GetProducts().ToList();
            // עוברת על הרשימה ועבור כל  אחד מייצרת יוזר קונטרול ומוסיפה
            foreach(BlProduct product in po)
            {
                //if(product.Kategor.KategorName== "עופות")
                //{
                //productsList = Global.sharat.GetproductBychoose(kategor.KategorName=="עופות");
                Ofot.Children.Add(new UCproduct(product));
                //}

            }
        }
    }
}
