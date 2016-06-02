namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Relationships
    {
        [Key]
        [StringLength(32)]
        public string Relationid { get; set; }

        public long? Entityid_M { get; set; }

        public long? Entityid_C { get; set; }

        [Required]
        [StringLength(8)]
        public string Relation { get; set; }

        public virtual s_Entity s_Entity { get; set; }

        public virtual s_Entity s_Entity1 { get; set; }
    }
}
