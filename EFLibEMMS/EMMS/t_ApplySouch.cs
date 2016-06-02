namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ApplySouch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_ApplySouch()
        {
            t_ApplyOfflineCase = new HashSet<t_ApplyOfflineCase>();
            t_ApplyOfflineCompany = new HashSet<t_ApplyOfflineCompany>();
            t_ApplyOfflineLand = new HashSet<t_ApplyOfflineLand>();
            t_ApplyOfflineLoan = new HashSet<t_ApplyOfflineLoan>();
            t_ApplyOfflineOther = new HashSet<t_ApplyOfflineOther>();
            t_ApplyOfflinePublic = new HashSet<t_ApplyOfflinePublic>();
            t_Quote = new HashSet<t_Quote>();
        }

        [Key]
        [StringLength(32)]
        public string ApplyID { get; set; }

        [Required]
        [StringLength(32)]
        public string MemberID { get; set; }

        public int? Source { get; set; }

        public int? ApplyType { get; set; }

        public DateTime? ApplyDate { get; set; }

        public int? State { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [StringLength(32)]
        public string SelectName { get; set; }

        [StringLength(8)]
        public string SelectSalutation { get; set; }

        [StringLength(32)]
        public string SelectTel { get; set; }

        [StringLength(64)]
        public string SelectEmail { get; set; }

        public virtual m_Member m_Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ApplyOfflineCase> t_ApplyOfflineCase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ApplyOfflineCompany> t_ApplyOfflineCompany { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ApplyOfflineLand> t_ApplyOfflineLand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ApplyOfflineLoan> t_ApplyOfflineLoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ApplyOfflineOther> t_ApplyOfflineOther { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ApplyOfflinePublic> t_ApplyOfflinePublic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Quote> t_Quote { get; set; }
    }
}
