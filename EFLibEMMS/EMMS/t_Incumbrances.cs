namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Incumbrances
    {
        [Key]
        [StringLength(32)]
        public string IncumbrancesID { get; set; }

        [StringLength(32)]
        public string LandID { get; set; }

        [StringLength(32)]
        public string Entityid { get; set; }

        [StringLength(32)]
        public string MemorialNo { get; set; }

        [StringLength(32)]
        public string DateInstrument { get; set; }

        [StringLength(32)]
        public string DateRegistration { get; set; }

        [StringLength(32)]
        public string Consideration { get; set; }

        [StringLength(32)]
        public string Nature { get; set; }

        [StringLength(256)]
        public string Remarks { get; set; }
    }
}
