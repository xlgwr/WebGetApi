namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ResultOfflineLoan
    {
        [Key]
        [StringLength(32)]
        public string ResultID { get; set; }

        [StringLength(32)]
        public string ReportID { get; set; }

        [StringLength(32)]
        public string Loanid { get; set; }

        public virtual t_ReportOfflineLoan t_ReportOfflineLoan { get; set; }
    }
}
