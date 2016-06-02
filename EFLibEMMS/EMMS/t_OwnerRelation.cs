namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_OwnerRelation
    {
        [Key]
        [StringLength(32)]
        public string OwnerRelationID { get; set; }

        [Required]
        [StringLength(32)]
        public string LandID { get; set; }

        public long? Entityid { get; set; }

        [StringLength(32)]
        public string MemorialNo { get; set; }

        [StringLength(32)]
        public string DateInstrument { get; set; }

        [StringLength(32)]
        public string DateRegistration { get; set; }

        [StringLength(32)]
        public string Consideration { get; set; }

        [StringLength(32)]
        public string Capacity { get; set; }

        [StringLength(256)]
        public string Remarks { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
