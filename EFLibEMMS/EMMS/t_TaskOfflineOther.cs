namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_TaskOfflineOther
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_TaskOfflineOther()
        {
            t_ReportOfflineOther = new HashSet<t_ReportOfflineOther>();
        }

        [Key]
        [StringLength(32)]
        public string TaskID { get; set; }

        [StringLength(32)]
        public string OrderListID { get; set; }

        [StringLength(32)]
        public string MemberID { get; set; }

        public int? Progress { get; set; }

        [StringLength(32)]
        public string UserID { get; set; }

        [StringLength(256)]
        public string Content { get; set; }

        [StringLength(32)]
        public string SelectName { get; set; }

        [StringLength(8)]
        public string SelectSalutation { get; set; }

        [StringLength(32)]
        public string SelectTel { get; set; }

        [StringLength(64)]
        public string SelectEmail { get; set; }

        public virtual t_OrderList t_OrderList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ReportOfflineOther> t_ReportOfflineOther { get; set; }
    }
}
