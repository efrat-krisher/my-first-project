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
    public class kosher

    {
        public kosher(Data.Kosher kosh)
        {
            this.KosherCode = kosh.KosherCode;
            this.KosherName = kosh.KosherName;
            this.KosherPicture = kosh.KosherPicture;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kosher()
        {
            this.products = new HashSet<BlProduct>();
        }
        [DataMember]
        public int KosherCode { get; set; }
        [DataMember]
        public string KosherName { get; set; }
        [DataMember]
        public byte[] KosherPicture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<BlProduct> products { get; set; }
        public Data.Kosher GetData()
        {
            Data.Kosher kosh = new Data.Kosher();
            kosh.KosherCode = this.KosherCode;       
            kosh.KosherName = this.KosherName;
            kosh.KosherPicture = this.KosherPicture;
            return kosh;
        }
        public void FillData(Data.Kosher kosh)
        {
            if (kosh != null)
            {
                kosh.KosherCode = this.KosherCode;
                kosh.KosherName = this.KosherName;
                kosh.KosherPicture = this.KosherPicture;
            }
        }
    }
}
