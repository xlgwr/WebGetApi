namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_PackageList
    {
        [Key]
        [StringLength(32)]
        public string PackageListID { get; set; }

        [StringLength(32)]
        public string ProductID { get; set; }

        public double? Price { get; set; }

        public int? Unit { get; set; }

        public double? Subtotal { get; set; }

        public int? Discount { get; set; }

        public double? DiscountPrice { get; set; }

        public double? DiscountSubtotal { get; set; }

        [StringLength(32)]
        public string PackageID { get; set; }

        public virtual m_Package m_Package { get; set; }

        public virtual m_Product m_Product { get; set; }
    }
}
