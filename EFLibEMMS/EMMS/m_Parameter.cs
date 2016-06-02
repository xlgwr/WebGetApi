namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_Parameter
    {
        [Key]
        [StringLength(32)]
        public string Paramkey { get; set; }

        [StringLength(32)]
        public string Paramvalue { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public int? Paramtype { get; set; }
    }
}
