namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Judgment
    {
        [StringLength(32)]
        public string id { get; set; }

        [StringLength(32)]
        public string Caseid { get; set; }

        [StringLength(32)]
        public string CaseNo { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [StringLength(128)]
        public string Path { get; set; }

        public virtual t_Case t_Case { get; set; }
    }
}
