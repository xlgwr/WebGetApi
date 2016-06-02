namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Loan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Loan()
        {
            t_Collateral = new HashSet<t_Collateral>();
        }

        [Key]
        [StringLength(32)]
        public string LoanID { get; set; }

        [StringLength(32)]
        public string LoanNo { get; set; }

        public long? Entityid_Reference { get; set; }

        public long? Entityid_Borrower { get; set; }

        public long? Entityid_Guarantor { get; set; }

        [StringLength(8)]
        public string LoanType { get; set; }

        [StringLength(8)]
        public string Currencies { get; set; }

        [StringLength(16)]
        public string ApplicationDate { get; set; }

        [StringLength(16)]
        public string ApplicatinAmount { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [StringLength(16)]
        public string PrincipalOS { get; set; }

        [StringLength(16)]
        public string TotalOS { get; set; }

        public DateTime? LastPaidDate { get; set; }

        public int? OverdueDays { get; set; }

        [StringLength(8)]
        public string CurrentStatus { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public virtual s_Entity s_Entity { get; set; }

        public virtual s_Entity s_Entity1 { get; set; }

        public virtual s_Entity s_Entity2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Collateral> t_Collateral { get; set; }
    }
}
