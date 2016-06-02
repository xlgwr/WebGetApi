namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_TaskOnlinePublic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_TaskOnlinePublic()
        {
            t_ReportOfflinePublic = new HashSet<t_ReportOfflinePublic>();
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

        public int? SmallType { get; set; }

        public int? ObjectType { get; set; }

        [StringLength(64)]
        public string FullName_En { get; set; }

        [StringLength(64)]
        public string FullName_Cn { get; set; }

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
        public virtual ICollection<t_ReportOfflinePublic> t_ReportOfflinePublic { get; set; }
    }
}
