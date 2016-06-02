namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class s_Unknown
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Entityid { get; set; }

        [StringLength(32)]
        public string FullName { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
