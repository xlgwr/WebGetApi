namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_PublicRelation
    {
        [Key]
        [StringLength(32)]
        public string PLRelationID { get; set; }

        [Required]
        [StringLength(32)]
        public string PublicID { get; set; }

        public long? Entityid { get; set; }

        public virtual s_Entity s_Entity { get; set; }

        public virtual t_PublicData t_PublicData { get; set; }
    }
}
