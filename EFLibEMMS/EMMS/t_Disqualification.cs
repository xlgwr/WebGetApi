namespace EFLibEMMS.EMMS
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_Disqualification")]
    public partial class t_Disqualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RecordID { get; set; }

        [ForeignKey("s_Entity")]
        public long Entityid { get; set; }

        public long HtmlPageID { get; set; }

        [Required]
        [StringLength(16)]
        public string ItemNo { get; set; }

        public int Language { get; set; }

        [StringLength(128)]
        public string CorporateName { get; set; }


        [StringLength(128)]
        public string ChineseName { get; set; }


        [StringLength(16)]
        public string IDCard { get; set; }



        [StringLength(32)]
        public string OverseasPassportID { get; set; }


        [StringLength(32)]
        public string PassportCountry { get; set; }



        [StringLength(16)]
        public string SameNo { get; set; }

        [JsonIgnore]
        public s_Entity s_Entity { get; set; }
    }
}
