namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_CompanyReport
    {
        [Key]
        [StringLength(32)]
        public string Reportid { get; set; }

        public long Entityid { get; set; }

        public int? Type { get; set; }

        [StringLength(64)]
        public string ReportName { get; set; }

        [StringLength(128)]
        public string PathPDF { get; set; }

        [StringLength(128)]
        public string PathExcel { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public virtual s_Company s_Company { get; set; }
    }
}
