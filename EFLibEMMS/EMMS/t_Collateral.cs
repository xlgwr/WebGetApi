namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Collateral
    {
        [Key]
        [StringLength(32)]
        public string CollateralID { get; set; }

        [StringLength(32)]
        public string LoanID { get; set; }

        [StringLength(256)]
        public string CollateralName { get; set; }

        [StringLength(32)]
        public string Cost { get; set; }

        [StringLength(128)]
        public string Path { get; set; }

        [StringLength(512)]
        public string Remark { get; set; }

        public virtual t_Loan t_Loan { get; set; }
    }
}
