namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_AppealCase
    {
        [StringLength(32)]
        public string id { get; set; }

        [Required]
        [StringLength(32)]
        public string CaseNo { get; set; }

        [Required]
        [StringLength(32)]
        public string OldCaseNo { get; set; }

        public DateTime? OldDate { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }
    }
}
