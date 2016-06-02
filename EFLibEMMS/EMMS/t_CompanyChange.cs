namespace EFLibEMMS.EMMS
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_CompanyChange")]
    public partial class t_CompanyChange
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Changeid { get; set; }
        
        [ForeignKey("s_Entity")]
        public long Entityid { get; set; }

        [StringLength(16)]
        public string CRNo { get; set; }

        public int Language { get; set; }
        
        public int Sort { get; set; }

        [StringLength(256)]
        public string ChangeContent_En { get; set; }


        [StringLength(256)]
        public string ChangeContent_Cn { get; set; }


        [StringLength(32)]
        public string EffectiveDate { get; set; }


        [StringLength(256)]
        public string Remark { get; set; }

        [JsonIgnore]
        public s_Entity s_Entity { get; set; }
    }
}
