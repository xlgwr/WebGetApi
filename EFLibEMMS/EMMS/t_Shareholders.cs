namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Shareholders
    {
        [Key]
        [StringLength(32)]
        public string Shareholderid { get; set; }

        [StringLength(32)]
        public string Entityid_C { get; set; }

        public long? Entityid_P { get; set; }

        [StringLength(8)]
        public string Percentage { get; set; }

        public virtual s_Person s_Person { get; set; }
    }
}
