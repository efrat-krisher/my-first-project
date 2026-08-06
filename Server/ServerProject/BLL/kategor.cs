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
    public class kategor

    {
        public kategor(Data.Kategor kate)
        {
            
            this.KategorCode=kate.KategorCode;
            this.KategorName=kate.KategorName;
            this.KategorPicture = kate.KategorPicture;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kategor()
        {
            this.products = new HashSet<BlProduct>();
        }
        [DataMember]
        public int KategorCode { get; set; }
        [DataMember]
        public string KategorName { get; set; }
        [DataMember]
        public byte[] KategorPicture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public  ICollection<BlProduct> products { get; set; }
        public Data.Kategor GetData()
        {
            Data.Kategor kate = new Data.Kategor();
            kate.KategorCode = this.KategorCode;
            kate.KategorName = this.KategorName;
            kate.KategorPicture = this.KategorPicture;
            return kate;
        }
        public void FillData(Data.Kategor kate)
        {
            if (kate != null)
            {             
                kate.KategorCode = this.KategorCode;
                kate.KategorName = this.KategorName;
                kate.KategorPicture = this.KategorPicture;
            }
        }
    }
}
