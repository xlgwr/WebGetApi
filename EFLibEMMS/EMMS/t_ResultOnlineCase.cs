namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ResultOnlineCase
    {
        [Key]
        [StringLength(32)]
        public string ResultID { get; set; }

        [StringLength(32)]
        public string ReportID { get; set; }

        [StringLength(32)]
        public string Caseid { get; set; }

        public virtual t_ReportOnlineCase t_ReportOnlineCase { get; set; }
    }
}
