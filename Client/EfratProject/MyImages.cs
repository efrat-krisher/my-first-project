using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace EfratProject
{
    internal class MyImages
    {
        public static string UploadImage_Dlg()
        {
            string filename = null;
            // יצירת אוביקט שיודע לפתוח חלון 
            OpenFileDialog dlg = new OpenFileDialog();
            // קביעת מסנן לבחירת קובץ רק סיומות אלו יוכלו להיבחר 
            dlg.Filter = "All Images | *.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.png" +
                "|JPEG Files (*.jpeg)|*.jpeg" +
                "|PNG Files (*.png)|*.png" +
                "|JPG Files (*.jpg)|*.jpg" +
                "|GIF Files (*.gif)|*.gif";
            //פותח חלונית בחירת תמונה ומחזיר האם נבחרה תמונה 
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                filename = dlg.FileName;
                filename = SaveImage(filename); //  שמירת התמונה בתיקייה המקומית
            }
            return filename;
        }


        public static string SaveImage(string sourcefileName)
        {
            string fileName = System.IO.Path.GetFileName(sourcefileName);
            string path = GetCurrentPath() + @"pictures\" + fileName;
            if (!File.Exists(path))
            {
                byte[] imgArray = File.ReadAllBytes(sourcefileName);
                var stream = new MemoryStream(imgArray);
                Image img = Image.FromStream(stream);

                img.Save(path);
            }
            return fileName;
        }

        public static void SendImage(string image)//פעולה שמקבלת שם תמונה ושולחת אותה לשרת
        {
            try
            {
                string path = GetCurrentPath() + @"pictures\" + image;
                byte[] imgArray = File.ReadAllBytes(path);//קריאת התמונה מהתיקיה המקומית
                Global.sharat.SaveImage(imgArray, image);//שליחה לפעולה בשרת
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static BitmapImage GetImage(string fileName)
        {
            if (fileName == "")
                return null;
            string path = GetCurrentPath() + @"pictures\" + fileName;
            if (!File.Exists(path))//אם הקובץ לא קיים בתיקייה מקומית
            {
                byte[] imageArr = Global.sharat.GetImage(fileName);//קבלת הקובץ מהשרת
                if (imageArr == null)
                    return null;
                var stream = new MemoryStream(imageArr);
                Image image = Image.FromStream(stream);
                image.Save(path);//שמירה בתיקיה מקומית
            }
            return new BitmapImage(new Uri(path));
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

    }
}

