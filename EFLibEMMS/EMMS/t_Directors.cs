namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Directors
    {
        [Key]
        [StringLength(32)]
        public string Directorsid { get; set; }

        public long? Entityid_C { get; set; }

        public long? Entityid_P { get; set; }

        public virtual s_Company s_Company { get; set; }

        public virtual s_Person s_Person { get; set; }
    }
}
