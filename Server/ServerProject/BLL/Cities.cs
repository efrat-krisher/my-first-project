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
    public class Cities
    {

        public Cities(Data.City c)
        {
            this.CityName = c.CityName;
            this.CityCode = c.CityCode; 
            this.DayInWeek = c.DayInWeek;
        }
        public Data.City getdatacity()
        {
            Data.City c = new Data.City();
            c.CityCode = this.CityCode;
            c.CityName = this.CityName;
            c.DayInWeek = this.DayInWeek;
            return c;

        }
        [DataMember]
        public int CityCode { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public int DayInWeek { get; set; }
        //[DataMember]
        //public bool AddCity { get; set; }

        public void FillData(Data.City c)
        {
            if (c != null)
                c.CityCode = this.CityCode;
            c.CityName = this.CityName;
            c.DayInWeek = this.DayInWeek;
        }
        public Data.City GetData()
        {
            Data.City c = new Data.City();
            c.CityCode = this.CityCode;
            c.CityName = this.CityName;
            c.DayInWeek = this.DayInWeek;
            return c;
        }

    }
}
