namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Court
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Court()
        {
            t_Case = new HashSet<t_Case>();
        }

        [Key]
        [StringLength(32)]
        public string CourtID { get; set; }

        [StringLength(64)]
        public string CourtName_En { get; set; }

        [StringLength(32)]
        public string CourtName_Cn { get; set; }

        [StringLength(16)]
        public string CourtCode { get; set; }

        [StringLength(128)]
        public string Address { get; set; }

        [StringLength(32)]
        public string Tel { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Case> t_Case { get; set; }
    }
}
