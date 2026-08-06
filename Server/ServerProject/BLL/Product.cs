using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ServerProject.Data;
//using ServerProject.BLL;

namespace ServerProject.BLL
{
   
    [DataContract]
    public class BlProduct
    {
        public BlProduct(Data.product p)
        {
            this.Kategor = new BLL.kategor(p.Kategor);
            this.Kosher = new BLL.kosher(p.Kosher);
            this.ProductCode = p.ProductCode;
            this.ProductName = p.ProductName;
            this.price = p.price;
            this.picture = p.ProductPicture;
            this.AmountIn =  p.AmountIn; 
            this.tari =  p.tari;
           // this.KategorCode = p.KategorCode;
           // this.Kategor = p.Kategor;
           // this.KosherCode = p.KosherCode;
           //this.Kosher = p.Kosher;


        }
        [DataMember]
        public bool tari { get; set; }
        [DataMember]
        public int ProductCode { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public double price { get; set; }
        [DataMember]
        public string picture { get; set; }
        [DataMember]
        public Nullable<double> AmountIn { get; set; }
        [DataMember]
        public  BLL.kategor Kategor { get; set; }
        [DataMember]
        public BLL.kosher Kosher { get; set; }

        public Data.product GetData()
        {
            Data.product p = new Data.product();
            p.ProductCode = this.ProductCode;
            p.ProductName = this.ProductName;
            p.price =   this.price;
            p.ProductPicture  = this.picture;
            p.AmountIn= this.AmountIn;
            if (Kosher != null)
                p.KosherCode = this.Kosher.KosherCode;
            if (Kategor != null)
                p.KategorCode = this.Kategor.KategorCode;
            return p;
        }   
        public void FillData(Data.product p)
        {
            if (p!=null)
            {
              if (Kosher != null)
                 p.KosherCode = this.Kosher.KosherCode;
                if (Kategor != null)
                 p.KategorCode = this.Kategor.KategorCode;
            p.ProductCode = this.ProductCode;
            p.ProductName = this.ProductName;
            p.price = this.price;
            p.AmountIn =  this.AmountIn;
            }
        }
        
        
    }
}
