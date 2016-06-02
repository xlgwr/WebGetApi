namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_QuoteList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_QuoteList()
        {
            t_OrderList = new HashSet<t_OrderList>();
        }

        [Key]
        [StringLength(32)]
        public string QuoteListID { get; set; }

        [Required]
        [StringLength(32)]
        public string QuoteID { get; set; }

        [StringLength(32)]
        public string ProductID { get; set; }

        [StringLength(64)]
        public string ProductName { get; set; }

        public int? UnitsBuy { get; set; }

        public double? Price { get; set; }

        public double? TotalAmount { get; set; }

        public DateTime? Validity { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public virtual m_Product m_Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_OrderList> t_OrderList { get; set; }

        public virtual t_Quote t_Quote { get; set; }
    }
}
