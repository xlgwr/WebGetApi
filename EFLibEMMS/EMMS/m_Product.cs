namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_Product()
        {
            m_MemberSetMealRelation = new HashSet<m_MemberSetMealRelation>();
            m_PackageList = new HashSet<m_PackageList>();
            m_ProductTable = new HashSet<m_ProductTable>();
            t_OrderList = new HashSet<t_OrderList>();
            t_QuoteList = new HashSet<t_QuoteList>();
        }

        [Key]
        [StringLength(32)]
        public string ProductID { get; set; }

        public int? BigType { get; set; }

        public int? SmallType { get; set; }

        [StringLength(64)]
        public string ProductName { get; set; }

        [StringLength(16)]
        public string Currency { get; set; }

        public double? Price { get; set; }

        public int? Validity { get; set; }

        public int? IsProduct { get; set; }

        public int? PeopleCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_MemberSetMealRelation> m_MemberSetMealRelation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_PackageList> m_PackageList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_ProductTable> m_ProductTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_OrderList> t_OrderList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_QuoteList> t_QuoteList { get; set; }
    }
}
