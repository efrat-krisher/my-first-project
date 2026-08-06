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
    public class Inviting
    {
    
        public Inviting(Data.inviting I)
        {
            this.Customer = new customers(I.Customer);
            this.dateBuy = I.dateBuy;
            this.dateSent = I.dateSent;  
            this.sent = I.sent;
            this.HazmanaCode=I.HazmanaCode;
        }
        [DataMember]
        public int HazmanaCode { get; set; }

        [DataMember]
        public System.DateTime dateBuy { get; set; }
        [DataMember]
        public System.DateTime dateSent { get; set; }
        [DataMember]
        public bool sent { get; set; }
        [DataMember]
        public customers Customer { get; set; }
        [DataMember]
        public Nullable<double> filnalPrice { get; set; }
        [DataMember]
        public string notes { get; set; }

        public void FillData(Data.inviting i)
        {
            if (i != null)
            {
               i.HazmanaCode = this.HazmanaCode;
                i.dateBuy = this.dateBuy;
                i.dateSent = this.dateSent;
                i.sent = this.sent;
                i.CodeCustomer = this.Customer.CodeCustomer;
            }
        }
    }
}
