namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_P_Representation
    {
        [StringLength(32)]
        public string id { get; set; }

        [StringLength(32)]
        public string Caseid { get; set; }

        public long? Entityid_R { get; set; }

        public int? GroupNO { get; set; }

        public virtual s_Entity s_Entity { get; set; }

        public virtual t_Case t_Case { get; set; }
    }
}
