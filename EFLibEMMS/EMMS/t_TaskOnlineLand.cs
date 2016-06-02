namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_TaskOnlineLand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_TaskOnlineLand()
        {
            t_ReportOnlineLand = new HashSet<t_ReportOnlineLand>();
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

        [StringLength(32)]
        public string LotType { get; set; }

        [StringLength(32)]
        public string LotNo { get; set; }

        [StringLength(64)]
        public string BuildName { get; set; }

        [StringLength(8)]
        public string HouseNO { get; set; }

        [StringLength(8)]
        public string RoomNO { get; set; }

        [StringLength(8)]
        public string Floor { get; set; }

        [StringLength(64)]
        public string Street { get; set; }

        [StringLength(8)]
        public string StreetNumber { get; set; }

        [StringLength(16)]
        public string Area { get; set; }

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
        public virtual ICollection<t_ReportOnlineLand> t_ReportOnlineLand { get; set; }
    }
}
