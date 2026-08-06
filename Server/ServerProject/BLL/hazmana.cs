using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ServerProject.Data;

namespace ServerProject.BLL
{
    [DataContract]
    public class hazmana
    {
        public hazmana(Data.Hazmana h)
        {
            this.product = new BlProduct(h.product);
            this.inviting = new Inviting(h.inviting);
            this.Amount = h.Amount;
            this.sent = h.sent;
            //this.CustumerAmountkg = h.CustumerAmountkg;
            //this.price = h.price;
        }
     
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public bool sent { get; set; }
        [DataMember]
        public  Inviting inviting { get; set; }
        [DataMember]
        public  BlProduct product { get; set; }

     
       
        public void FillData(Data.Hazmana h)
        {
            if (h != null)
            {
                if (product != null)
                    h.ProductCode = this.product.ProductCode;
                if (inviting != null)
                    h.HazmanaCode = this.inviting.HazmanaCode;
                h.Amount = this.Amount;
                h.sent = this.sent;

            }      
        }


    }
}
