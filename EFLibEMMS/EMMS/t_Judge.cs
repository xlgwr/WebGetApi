namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Judge
    {
        [StringLength(32)]
        public string id { get; set; }

        [StringLength(32)]
        public string Caseid { get; set; }

        public long? Entityid { get; set; }

        public virtual s_Entity s_Entity { get; set; }

        public virtual s_Person s_Person { get; set; }
    }
}
