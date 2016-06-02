namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ResultOfflineCom
    {
        [Key]
        [StringLength(32)]
        public string ResultID { get; set; }

        [StringLength(32)]
        public string ReportID { get; set; }

        [StringLength(32)]
        public string Companyid { get; set; }

        public virtual t_ReportOfflineCom t_ReportOfflineCom { get; set; }
    }
}
