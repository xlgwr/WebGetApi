namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_DownLoadReport
    {
        [Key]
        [StringLength(32)]
        public string DownLoadID { get; set; }

        [StringLength(32)]
        public string ResultID { get; set; }

        [StringLength(32)]
        public string Reportid { get; set; }
    }
}
