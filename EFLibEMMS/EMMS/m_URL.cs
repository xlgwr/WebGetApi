namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_URL
    {
        [Key]
        [StringLength(32)]
        public string URLid { get; set; }

        [StringLength(64)]
        public string URLname { get; set; }

        [StringLength(256)]
        public string URL { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }
    }
}
