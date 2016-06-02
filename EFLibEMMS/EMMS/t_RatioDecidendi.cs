namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_RatioDecidendi
    {
        [Key]
        [StringLength(32)]
        public string JudgementID { get; set; }

        [StringLength(32)]
        public string Caseid { get; set; }

        [Required]
        [StringLength(32)]
        public string CaseNo { get; set; }

        public DateTime? ResultDate { get; set; }

        public int? Language { get; set; }

        [Column(TypeName = "text")]
        public string Results { get; set; }
    }
}
