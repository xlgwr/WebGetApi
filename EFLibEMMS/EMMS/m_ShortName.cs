namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_ShortName
    {
        [Key]
        [StringLength(32)]
        public string Shortid { get; set; }

        [StringLength(16)]
        public string Type { get; set; }

        [StringLength(16)]
        public string ShortName { get; set; }

        [StringLength(64)]
        public string LongName { get; set; }

        public int? Sort { get; set; }
    }
}
