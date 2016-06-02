namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Quote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Quote()
        {
            t_QuoteList = new HashSet<t_QuoteList>();
        }

        [Required]
        [StringLength(32)]
        public string ApplyID { get; set; }

        [Key]
        [StringLength(32)]
        public string QuoteID { get; set; }

        [Required]
        [StringLength(32)]
        public string MemberID { get; set; }

        public DateTime? QuoteDate { get; set; }

        [StringLength(16)]
        public string Currency { get; set; }

        public int? QuoteConfirm { get; set; }

        [StringLength(128)]
        public string PathQuote { get; set; }

        [StringLength(128)]
        public string PathContract { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public virtual m_Member m_Member { get; set; }

        public virtual t_ApplySouch t_ApplySouch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_QuoteList> t_QuoteList { get; set; }
    }
}
