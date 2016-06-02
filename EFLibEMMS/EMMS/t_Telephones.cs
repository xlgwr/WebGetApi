namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Telephones
    {
        [Key]
        [StringLength(32)]
        public string PhoneID { get; set; }

        public long Entityid { get; set; }

        public int PhoneType { get; set; }

        [StringLength(32)]
        public string PhoneNumber { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
