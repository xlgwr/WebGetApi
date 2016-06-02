namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Plaintiff
    {
        [StringLength(32)]
        public string id { get; set; }

        [Required]
        [StringLength(32)]
        public string Caseid { get; set; }

        public long Entityid { get; set; }

        public int GroupNO { get; set; }

        public virtual s_Entity s_Entity { get; set; }

        public virtual t_Case t_Case { get; set; }
    }
}
