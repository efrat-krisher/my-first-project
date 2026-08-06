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
using static System.Net.Mime.MediaTypeNames;

namespace EfratProject
{
    /// <summary>
    /// Interaction logic for Director.xaml
    /// </summary>
    public partial class Director : Page
    {
        public Director()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {   // כאן אני רוצה לשלוח לשרת את הסיסמה שהוקשה ולהודיע האם היא נכונה   
            Service1Client sharat = new Service1Client();
            if (sharat.IsPasswordCorrect(txt.Password))
            {
                NavigationService f = NavigationService.GetNavigationService(this);
                f.Navigate(new Director1());
            }
            else
                MessageBox.Show("הסיסמה שגויה");
        }
       
        
    }
}
