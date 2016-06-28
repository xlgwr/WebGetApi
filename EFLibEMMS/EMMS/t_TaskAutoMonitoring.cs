namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_TaskAutoMonitoring
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_TaskAutoMonitoring()
        {
            t_TaskAutoGroup = new HashSet<t_TaskAutoGroup>();
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

        public int? AgeLimit { get; set; }

        public virtual t_OrderList t_OrderList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskAutoGroup> t_TaskAutoGroup { get; set; }
    }
}