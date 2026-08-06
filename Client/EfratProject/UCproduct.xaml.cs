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
    /// Interaction logic for UCproduct.xaml
    /// </summary>
    public partial class UCproduct : UserControl      
    {


        private BlProduct p;

        public BlProduct P
        {
            get { return p; }
            set { p = value; }
        }

        private double amount = 0;
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public UCproduct(BlProduct prod)
        {
            InitializeComponent();
            p = prod;
            this.DataContext = p;
           
            prprice.Text = p.price.ToString();
            Pimage.Source = MyImages.GetImage(p.picture);
            hazmana h = Global.recepit.FirstOrDefault(x => x.product.ProductCode == p.ProductCode);
            if (h != null)
            {
                Amount1.Text = h.Amount.ToString();
                BtnAdd.Content = "עדכן שינוי";
                this.BorderBrush = new SolidColorBrush(Color.FromArgb(200, 0, 0, 0));
                this.BorderThickness = new Thickness(2);
                amount = h.Amount;

            }
        }
    

        private void Minus(object sender, RoutedEventArgs e)
        {

            if (amount > 0)
            {
                amount -= 0.5;
                Amount1.Text = amount.ToString();
            }
            if(amount==0)
               this.BorderThickness = new Thickness(0);
          

        }

        private void Plus(object sender, RoutedEventArgs e)
        {
           
            if (p.AmountIn >= amount)
            {
                amount += 0.5;
                Amount1.Text = amount.ToString();
            }
            else
                Finished.Visibility = Visibility;

        }

       
        private void Add(object sender, RoutedEventArgs e)
        {

            //לבדוק אם זה כבר קיים
            hazmana h = (Global.recepit.FirstOrDefault(x => x.product.ProductCode == p.ProductCode));
            if (h == null)

            {
                h = new hazmana();
                h.product = p;
                h.Amount = float.Parse(amount.ToString());
                //h.price = (p.price) * float.Parse(amount.Text);
                if (amount != 0)
                { 
                    Global.recepit.Add(h);              
                    this.BorderBrush = new SolidColorBrush(Color.FromArgb(200, 0, 0, 0));
                    this.BorderThickness = new Thickness(2);
                }
            }
            else
            {
                h.Amount=float.Parse(amount.ToString());
                if(amount==0)
                {
                    Global.recepit.Remove(h);
                    this.BorderThickness = new Thickness(0);
                    BtnAdd.Content = "הוספה";
                }
            }
        }
    }
}
