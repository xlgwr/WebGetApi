namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_ProductTable
    {
        [Key]
        [StringLength(32)]
        public string ProductTableID { get; set; }

        public int? SmallType { get; set; }

        [StringLength(32)]
        public string PublicTable { get; set; }

        [StringLength(32)]
        public string ProductID { get; set; }

        public virtual m_Product m_Product { get; set; }
    }
}
