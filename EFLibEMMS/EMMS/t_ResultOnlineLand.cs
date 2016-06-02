namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ResultOnlineLand
    {
        [Key]
        [StringLength(32)]
        public string ResultID { get; set; }

        [StringLength(32)]
        public string ReportID { get; set; }

        [StringLength(32)]
        public string Landid { get; set; }

        public virtual t_ReportOnlineLand t_ReportOnlineLand { get; set; }

        public virtual t_ReportOnlineLoan t_ReportOnlineLoan { get; set; }
    }
}
