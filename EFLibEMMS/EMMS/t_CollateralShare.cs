namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_CollateralShare
    {
        [Key]
        [StringLength(256)]
        public string CollateralShareID { get; set; }

        [StringLength(32)]
        public string LoanID { get; set; }

        [StringLength(32)]
        public string Share { get; set; }

        [StringLength(32)]
        public string StockCode { get; set; }

        [StringLength(32)]
        public string ShareAmount { get; set; }

        [StringLength(32)]
        public string Price { get; set; }

        [StringLength(32)]
        public string TotalValue { get; set; }
    }
}
