namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_InvoiceList
    {
        [Key]
        [StringLength(32)]
        public string InvoiceListID { get; set; }

        [StringLength(32)]
        public string InvoiceID { get; set; }

        [StringLength(32)]
        public string OrderListID { get; set; }

        [StringLength(32)]
        public string ProductID { get; set; }

        [StringLength(32)]
        public string ProductName { get; set; }

        public int? UnitsOver { get; set; }

        [StringLength(32)]
        public string Price { get; set; }

        [StringLength(32)]
        public string TotalAmount { get; set; }

        public virtual t_Invoice t_Invoice { get; set; }

        public virtual t_OrderList t_OrderList { get; set; }
    }
}
