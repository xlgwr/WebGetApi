namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_MediaReport
    {
        [Key]
        [StringLength(32)]
        public string MediaReportID { get; set; }

        public long? Entityid { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(64)]
        public string Subject { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public DateTime? ReportDate { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
