namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Education
    {
        [Key]
        [StringLength(32)]
        public string Educationid { get; set; }

        public long? Entityid { get; set; }

        [StringLength(64)]
        public string Institute { get; set; }

        [StringLength(32)]
        public string InstituteType { get; set; }

        [StringLength(16)]
        public string Degree { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public virtual s_Person s_Person { get; set; }
    }
}
