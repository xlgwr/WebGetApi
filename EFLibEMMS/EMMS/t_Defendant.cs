namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Defendant
    {
        [StringLength(32)]
        public string id { get; set; }

        [StringLength(32)]
        public string Caseid { get; set; }

        public long? Entityid { get; set; }

        public int? GroupNO { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
