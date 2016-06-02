namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Invoice()
        {
            t_Payment = new HashSet<t_Payment>();
            t_InvoiceList = new HashSet<t_InvoiceList>();
        }

        [Key]
        [StringLength(32)]
        public string InvoiceID { get; set; }

        [Required]
        [StringLength(32)]
        public string MemberID { get; set; }

        public DateTime InvoiceDate { get; set; }

        [StringLength(16)]
        public string Currency { get; set; }

        public double? Total { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [StringLength(32)]
        public string EmailID { get; set; }

        public int? PayState { get; set; }

        public virtual m_Member m_Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Payment> t_Payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_InvoiceList> t_InvoiceList { get; set; }
    }
}
