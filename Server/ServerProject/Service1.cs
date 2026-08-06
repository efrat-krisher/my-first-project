using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServerProject.BLL;
using ServerProject.Data;
using System.Drawing;
using System.IO;


namespace ServerProject
{
    public class Service1 : IService1
    {
        static string CorrectPassword = "1234";
        static EfratDBEntities db = new EfratDBEntities();
        public bool IsPasswordCorrect(string password)
        {
            if (password == CorrectPassword)
                return true; //אם נכון
            return false; // אם שגוי
        }
        public bool ChangePassword(string newPassword, string oldPassward)
        {
            if (oldPassward == CorrectPassword)
            {
                CorrectPassword = newPassword;
                return true;
            }
            return false;
        }
        public int AmountCustomers()
        {
            return db.Customers.Count();
        }
        public List<BLL.customers> GetCustomers()
        {
            //Dataמביאים את הנתונים מ
            List<Data.Customer> list1 = db.Customers.ToList();
            // Bll ממירים אותה לרשימה מסוג מחלקה פשוטה יותר בשכבת
            List<BLL.customers> list2 = list1.Select(x => new BLL.customers(x)).OrderBy(x=> x.LastName). ToList();
            return list2;
        }
        public List<BLL.Inviting> GetInvitings()
        { //Dataמביאים את הנתונים מ
            List<Data.inviting> list1 = db.invitings.ToList();
            // Bll ממירים אותה לרשימה מסוג מחלקה פשוטה יותר בשכבת
            List<BLL.Inviting> list2 = list1.Select(x => new BLL.Inviting(x)).ToList();
            return list2;
        }
        public bool AddCustomers(BLL.customers c)
        {
            Data.Customer cData =c.GetData();
            db.Customers.Add(cData);
            int result=db.SaveChanges();
            return result > 0;
        }
        public BLL.customers GetCustomerByPhone(string phone)
        {
            Data.Customer c = db.Customers.FirstOrDefault(x => x.phone == phone);
            if (c == null) return null;
            return new BLL.customers(c);
        }

        public List<BLL.Cities> GetCity()
        {
            //Dataמביאים את הנתונים מ
            List<Data.City> list1 = db.Cities.ToList();
            // Bll ממירים אותה לרשימה מסוג מחלקה פשוטה יותר בשכבת
            List<BLL.Cities> list2 = list1.Select(x => new BLL.Cities(x)).OrderBy(x => x.CityName).ToList();  
            return list2;
        }

        public bool UpdateCustomer(BLL.customers c)
        {
            //מביאה את האוביקט המתאים מתוך הרשימה שבדטה
            Data.Customer mData = db.Customers.FirstOrDefault(x => x.CodeCustomer == c.CodeCustomer);
            //ממלאת א האוביקט שהגיע מהרשימה בפרטים עדכניים
            //שנמצאים באוביקט מסוג בי אל אל שהגיע מהלקוח
            c.FillData(mData);
            //מפעילה את השינוי
            int result = db.SaveChanges();
            //מחזירה הודעה האם קרה שינוי
            return result > 0;
           
        }
        public bool UpdateCity(BLL.Cities C)
        {
            //מביאה את האוביקט המתאים מתוך הרשימה שבדטה
            Data.City mData = db.Cities.FirstOrDefault(x => x.CityCode == C.CityCode);
            //ממלאת א האוביקט שהגיע מהרשימה בפרטים עדכניים
            //שנמצאים באוביקט מסוג בי אל אל שהגיע מהלקוח
            C.FillData(mData);
            //מפעילה את השינוי
            int result = db.SaveChanges();
            //מחזירה הודעה האם קרה שינוי
            return result > 0;
        }
        public bool UpdateKosher(BLL.kosher kosh)
        {
            //מביאה את האוביקט המתאים מתוך הרשימה שבדטה
            Data.Kosher mData = db.Koshers.FirstOrDefault(x => x.KosherCode == kosh.KosherCode);
            //ממלאת א האוביקט שהגיע מהרשימה בפרטים עדכניים
            //שנמצאים באוביקט מסוג בי אל אל שהגיע מהלקוח
            kosh.FillData(mData);
            //מפעילה את השינוי
            int result = db.SaveChanges();
            //מחזירה הודעה האם קרה שינוי
            return result > 0;
        }
        public bool UpdateProduct(BLL.BlProduct p)
        {
            //מביאה את האוביקט המתאים מתוך הרשימה שבדטה
            Data.product mData = db.products.FirstOrDefault(x => x.ProductCode == p.ProductCode);
            //ממלאת א האוביקט שהגיע מהרשימה בפרטים עדכניים
            //שנמצאים באוביקט מסוג בי אל אל שהגיע מהלקוח
            p.FillData(mData);
            //מפעילה את השינוי
            int result = db.SaveChanges();
            //מחזירה הודעה האם קרה שינוי
            return result > 0;
        }
      
        public List<BLL.BlProduct> GetProducts()
        {
            List<Data.product> list1 = db.products.ToList();
            List<BLL.BlProduct> list2 = list1.Select(x => new BLL.BlProduct(x)).OrderBy(x => x.ProductName).ToList();
            return list2;

        }

        public bool AddProduct(BlProduct p)//הוספת מוצר חדש
        {
            Data.product cData = p.GetData();
            db.products.Add(cData);
            int result = db.SaveChanges();
            return result > 0;
        }
       
        public bool AddKosher(BLL.kosher k)
        {
            Data.Kosher cData = k.GetData();
            db.Koshers.Add(cData);
            int result = db.SaveChanges();
            return result > 0;
        }
      public List<BLL.kosher> GetKosher()
        {
            //Dataמביאים את הנתונים מ
            List<Data.Kosher> list1 = db.Koshers.ToList();
            // Bll ממירים אותה לרשימה מסוג מחלקה פשוטה יותר בשכבת
            List<BLL.kosher> list2 = list1.Select(x => new BLL.kosher(x)).ToList();
            return list2;
      }  
        public List<BLL.Inviting> GetInviting()
        {
            //Dataמביאים את הנתונים מ
            List<Data.inviting> list1 = db.invitings.ToList();
            // Bll ממירים אותה לרשימה מסוג מחלקה פשוטה יותר בשכבת
            List<BLL.Inviting> list2 = list1.Select(x => new BLL.Inviting(x)).ToList();
            return list2;
      }
       public List<BLL.kategor> GetKategor()
        {   //Dataמביאים את הנתונים מ
            List<Data.Kategor> list1 = db.Kategors.ToList();
            // Bll ממירים אותה לרשימה מסוג מחלקה פשוטה יותר בשכבת
            List<BLL.kategor> list2 = list1.Select(x => new BLL.kategor(x)).ToList();
            return list2;
        }
        //public string GetKategorName()
        //{
        //    KategorName
        //}
        public bool AddCity(BLL.Cities c)
        {
            Data.City cData = c.GetData();
            db.Cities.Add(cData);
            int result = db.SaveChanges();
            return result > 0;
        }
        public bool deleteproduct(BLL.BlProduct p)
        {
            Data.product pData = db.products.FirstOrDefault(x => x.ProductCode == p.ProductCode );
            db.products.Remove(pData);
            int result = db.SaveChanges();
            return result > 0;
        }
        public bool deleteCity(BLL.Cities c)
        {
            Data.City cData = db.Cities.FirstOrDefault(x => x.CityCode == c.CityCode);
            db.Cities.Remove(cData);
            int result = db.SaveChanges();
            return result > 0;
        }
        public bool deleteKosher(BLL.kosher kosh)
        {
            Data.Kosher kData = db.Koshers.FirstOrDefault(x => x.KosherCode == kosh.KosherCode);
            db.Koshers.Remove(kData);
            int result = db.SaveChanges();
            return result > 0;
        }
        public bool deleteCustomer(BLL.customers c)
        {
            Data.Customer cData = db.Customers.FirstOrDefault(x => x.CodeCustomer == c.CodeCustomer);
            db.Customers.Remove(cData);
            int result = db.SaveChanges();
            return result > 0;
        } 
        public bool deleteHazmana(BLL.Inviting I)
        {
            Data.inviting cData = db.invitings.FirstOrDefault(x => x.HazmanaCode == I.HazmanaCode);
            db.invitings.Remove(cData);
            int result = db.SaveChanges();
            return result > 0;
        }
        public byte[] GetImage(string fileName)
        {
            string path = GetCurrentPath() + @"ServerProject\Pictures\" + fileName;
            if (File.Exists(path))
                return File.ReadAllBytes(path);//קורא את קובץ התמונה מהמקום שלה וממיר אותה למערך ביטים
            return null;//או תמונת ברירת מחדל
        }
        //פונקציה שמביאה את הנתיב של אותו פרויקט
        public static string GetCurrentPath()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 3; i++)
            {
                path += arr[i] + "\\";
            }
            return path;
        }
        public void SaveImage(byte[] imageArray, string fileName)
        {
            var stream = new MemoryStream(imageArray);
            Image img = Image.FromStream(stream);
            string path = GetCurrentPath() + @"ServerProject\Pictures\" + fileName;
            img.Save(path);
        }
  
        //מוסיף הזמנה גם לטבלת הרכישה וגם לפרטי הזמנה
        public bool CreateOrder(BLL.Inviting invite, List<hazmana> LProducts)
        {
            Data.inviting orderData = new Data.inviting();
            invite.FillData(orderData);
            db.invitings.Add(orderData);
            int result = db.SaveChanges();
            foreach (hazmana pro in LProducts)
            {
                Data.Hazmana H = new Data.Hazmana();              
                pro.FillData(H);
                H.inviting = orderData;
                db.Hazmanas.Add(H);
            }
            result += db.SaveChanges();
            return (result > 0);
        }
        public List<BLL.BlProduct> SearchProducts(String P)
        {
            List<product> PRODUCT = db.products.Where(x => x.ProductName.StartsWith(P)).ToList();
            List<BLL.BlProduct> list2 = PRODUCT.Select(x => new BLL.BlProduct(x)).ToList();
            return list2;
        }
        public List<BlProduct> GetproductBychoose(kategor w)
        {
            List<BlProduct> PRODUCT = GetProducts();
            return PRODUCT.Where(x => x.Kategor.KategorName == w.KategorName).ToList();
        }
        public List<hazmana> GetItemsinOrder()
        {
            List<Data.Hazmana> list = db.Hazmanas.ToList();
            List<BLL.hazmana> list2 = list.Select(x => new BLL.hazmana(x)).ToList();
            return list2;
        }
        public bool RemoveProductFromInvite(BLL.hazmana p)
        {
            Data.Hazmana p1 = db.Hazmanas.FirstOrDefault(x => x.inviting.HazmanaCode == p.inviting.HazmanaCode);
            db.Hazmanas.Remove(p1);
            int result = db.SaveChanges();
            return false;/*result > 0*/
        }
        public List<BLL. Inviting> GetOrdersByCity(int code)
        {
            List<Data.inviting> list = db.invitings.Where(x=>x.Customer.City.CityCode==code).ToList();
            return list.Select(x => new BLL.Inviting(x)).ToList();
        }
        public List<BLL. Inviting> GetOrdersByDay()

        {
            //        List<Data.inviting> list = db.invitings.Where(x=>x.Customer.City.CityCode==code).ToList(); 
            //List<Data.inviting> list = db.invitings.Where(x=>x .Customer.City.DayInWeek==07/11/2024).ToList();     
            List<Data.inviting> list = db.invitings.Where(x=>x .Customer.City.DayInWeek==07/11/2024).ToList(); 
            //List<Data.inviting> list = db.invitings.Where(x => x.dateSent == DateTime.Today).ToList();
           //List<Data.inviting> list = db.invitings.Where(x => x.dateSent = 11/07/2024 ).ToList();
            return list.Select(x => new BLL.Inviting(x)).ToList();
        }
    }
}
