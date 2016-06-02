namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_OrderList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_OrderList()
        {
            t_InvoiceList = new HashSet<t_InvoiceList>();
            t_TaskAutoMonitoring = new HashSet<t_TaskAutoMonitoring>();
            t_TaskOfflineCase = new HashSet<t_TaskOfflineCase>();
            t_TaskOfflineCompany = new HashSet<t_TaskOfflineCompany>();
            t_TaskOfflineLand = new HashSet<t_TaskOfflineLand>();
            t_TaskOfflineLoan = new HashSet<t_TaskOfflineLoan>();
            t_TaskOfflineOther = new HashSet<t_TaskOfflineOther>();
            t_TaskOnlineCase = new HashSet<t_TaskOnlineCase>();
            t_TaskOnlineCompany = new HashSet<t_TaskOnlineCompany>();
            t_TaskOnlineLand = new HashSet<t_TaskOnlineLand>();
            t_TaskOnlineLoan = new HashSet<t_TaskOnlineLoan>();
            t_TaskOnlinePublic = new HashSet<t_TaskOnlinePublic>();
        }

        [Key]
        [StringLength(32)]
        public string OrderListID { get; set; }

        [StringLength(32)]
        public string OrderID { get; set; }

        [StringLength(32)]
        public string QuoteListID { get; set; }

        [StringLength(32)]
        public string SetMealID { get; set; }

        [StringLength(32)]
        public string ProductID { get; set; }

        [StringLength(64)]
        public string ProductName { get; set; }

        public int? UnitsBuy { get; set; }

        public int? UnitsUsed { get; set; }

        public int? UnitsInvoice { get; set; }

        public double? Price { get; set; }

        public double? TotalAmount { get; set; }

        public int? Validity { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public virtual m_Package m_Package { get; set; }

        public virtual m_Product m_Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_InvoiceList> t_InvoiceList { get; set; }

        public virtual t_Order t_Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskAutoMonitoring> t_TaskAutoMonitoring { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOfflineCase> t_TaskOfflineCase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOfflineCompany> t_TaskOfflineCompany { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOfflineLand> t_TaskOfflineLand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOfflineLoan> t_TaskOfflineLoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOfflineOther> t_TaskOfflineOther { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOnlineCase> t_TaskOnlineCase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOnlineCompany> t_TaskOnlineCompany { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOnlineLand> t_TaskOnlineLand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOnlineLoan> t_TaskOnlineLoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_TaskOnlinePublic> t_TaskOnlinePublic { get; set; }

        public virtual t_QuoteList t_QuoteList { get; set; }
    }
}
