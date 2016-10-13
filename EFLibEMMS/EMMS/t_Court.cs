namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Court
    {
      

        [Key]
        [StringLength(32)]
        public string CourtID { get; set; }

        [StringLength(64)]
        public string CourtName_En { get; set; }

        [StringLength(32)]
        public string CourtName_Cn { get; set; }

        [StringLength(16)]
        public string CourtCode { get; set; }

        [StringLength(128)]
        public string Address { get; set; }

        [StringLength(32)]
        public string Tel { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }
    }
}
