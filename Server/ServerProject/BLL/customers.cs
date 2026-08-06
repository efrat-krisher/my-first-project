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
    public class customers
    {    
        public customers(Data.Customer c)
        {   
            this.CodeCustomer = c.CodeCustomer; 
            this.FirstName = c.FirstName;      
            this.LastName = c.LastName;
            this.adress = c.adress;     
            this.hous = c.hous;      
            this.apartment = c.apartment;  
            this.floor = c.floor;
            this.phone = c.phone;
            this.mail = c.mail;
            if (c.City != null)
            {
              this.city1 = new BLL.Cities(c.City);//תכונת מפתח זר              
            }
               
        }
        [DataMember]
        public int CodeCustomer { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public virtual Cities city1 { get; set; }
        [DataMember]
        public string adress { get; set; }
        [DataMember]
        public int hous { get; set; }
        [DataMember]
        public string apartment { get; set; }
        [DataMember]
        public string floor { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string mail { get; set; }
        public Data.Customer GetData()
        {
            Data.Customer c = new Data.Customer();
            c.CodeCustomer = this.CodeCustomer;
            c.FirstName = this.FirstName;   
            c.LastName = this.LastName;
            c.hous = this.hous; 
            c.apartment = this.apartment;
            c.adress=this.adress;
            c.floor = this.floor;
            c.phone = this.phone;
            c.mail = this.mail;
            //c.CodeCity = this.CodeCity;
            //c.City = Converters.GetDalCity(this.city);
            c.CodeCity = this.city1.CityCode;
            return c;
        }
        public void FillData(Data.Customer c)
        {
            //Data.Customer c = new Data.Customer();
            if (c!=null)
            {
                if (this.city1 != null)
                    c.CodeCity = this.city1.CityCode;
            c.CodeCustomer = this.CodeCustomer;
            c.FirstName = this.FirstName;   
            c.LastName = this.LastName; 
            c.hous = this.hous; 
            c.apartment = this.apartment;
            c.adress=this.adress;
            c.floor = this.floor;
            c.phone = this.phone;
            c.mail = this.mail;
                //c.CodeCity = this.CodeCity;
                //c.City = Converters.GetDalCity(this.city);
              
            }        
        }

    }
}
