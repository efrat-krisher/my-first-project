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
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Page
    {

        public List<kategor> CategoriesList = new List<kategor>();
        public List<kosher> KosherList = new List<kosher>();
        int Status;
        BlProduct p;
        //1=הוספת מוצר 
        //2=עדכון פרטי המוצרים 
        //3=קריאה בלבד
        //public object MyImage { get; set; }
        public AddNewProduct()
        {
            InitializeComponent();
            p = new BlProduct();
            this.DataContext = p;
            cmKosher.ItemsSource = Global.sharat.GetKosher();

           CategoriesList = Global.sharat.GetKategor();
            cmKategor.ItemsSource = CategoriesList;
            // לא צריך cmTari.ItemsSource = Global.sharat.GetTari();
            Status = 1;         
        }
       
            
           
          
        public AddNewProduct(BlProduct p)
        {
            InitializeComponent();
            this.p = p;
            this.DataContext = p;
            //CategoriesList = Global.sharat.GetKategor().ToList();
            List<kategor> CategoriesList = Global.sharat.GetKategor();
            cmKategor.ItemsSource = CategoriesList;
            cmKategor.SelectedItem = CategoriesList.FirstOrDefault(x => x.KategorCode == p.Kategor.KategorCode);
            //List<Kosher> KosherList = Global.sharat.GetKosher();
            //cmKosher.ItemsSource = KosherList;
            //cmKosher.SelectedItem = KosherList.FirstOrDefault(x => x.KosherCode == p.Kosher.KosherCode);
            Status = 2;
        }



        private void AddPicture(object sender, RoutedEventArgs e)
        {
            string fileName = MyImages.UploadImage_Dlg();
            if (fileName != null)
            {
                p.picture = fileName;
                image1.Source = MyImages.GetImage(fileName);/*new BitmapImage(new Uri(fileName));*/// MyImages.GetImage( fileName);
            }
            if(image1 != null)
                r.Visibility = Visibility.Visible;
        }
        public static string GetCurrentPath()
        {
            //מחזירה את מיקום קובץ ההרצה של הפרויקט
            string path = System.IO.Directory.GetCurrentDirectory();
            //מייצרים ממנו מחרוזת חדשה ללא 2 התיקיות האחרונות
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 2; i++)
            {
                path += arr[i] + "\\";
            }
            return path;//קיבלנו את המיקום של תיקיית הפרויקט
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Status == 1)//במצב הוספה
            {
         
                if (p.Kategor==null||p.Kosher==null|| p.ProductName == null || p.ProductName == "" /*|| p.AmountIn == null || p.AmountIn == "" || p.price == null || p.price == ""*/)
                    txtbed.Text = "נא להכניס נתונים תקינים";
                else
                {
                    //if (p.KategorCode == 0)
                    //    p.KategorCode = (int)cmKategor.SelectedValue;

                    //if (p.KosherCode  == 0)
                    //    p.KosherCode = (int)cmKosher.SelectedValue;

                    if (Global.sharat.AddProduct(p))
                    {
                        if (p.picture != null)
                            MyImages.SendImage(p.picture);
                        pass1.Visibility = Visibility = Visibility.Visible;
                        pass.Visibility = Visibility = Visibility.Visible;
                        txtgood.Text = "המוצר נוסף בהצלחה";
                       

                    }
                    else
                        txtbed.Text = "ההוספה נכשלה";

                }

            }
            

        }
        private void deletp(object sender, RoutedEventArgs e)
        {
            p.picture = null;
            image1.Source = null;
        }

        private void Go(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new lstproducts());
        }

        private void Go1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AddNewProduct());
        }
    }
}
