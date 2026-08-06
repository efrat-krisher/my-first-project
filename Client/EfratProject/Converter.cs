using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace EfratProject
{
    internal class Converter: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool x = (bool)value; // הופך את אישר התקנון שהיה מסומן ב'וי' ל-כן/לא
            if (x == true)
                return "כן";
            return "לא";
        }
        


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();

            }
    }
    internal class ConvertDays : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = (int)value; // הופך מספר יום לשמו 
            if (x == 1)
                return "ראשון";
            else if (x == 2)
                return "שני";
            else if (x == 3)
                return "שלישי";
            else if (x == 4)
                return "רביעי";
            else if (x == 5)
                return "חמישי";
            else
                return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();

        }
    }
    internal class PicturConvert : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null && value.ToString() != "")
                    return MyImages.GetImage(value.ToString()); // מציג את התמונה שבחר
            return MyImages.GetImage("noimage.png"); // באם אין תנוה - מציג תמונה ברירת מחדל 
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

        
        }
    
}
