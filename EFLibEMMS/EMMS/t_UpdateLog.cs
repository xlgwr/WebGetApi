namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_UpdateLog
    {
        [Key]
        [StringLength(32)]
        public string Updateid { get; set; }

        [StringLength(32)]
        public string Caseid { get; set; }

        [StringLength(256)]
        public string Content { get; set; }

        public DateTime? updtime { get; set; }

        [StringLength(16)]
        public string upduser { get; set; }

        public virtual t_Case t_Case { get; set; }
    }
}
