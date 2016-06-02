namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Emails
    {
        [Key]
        [StringLength(32)]
        public string Emailid { get; set; }

        public long Entityid { get; set; }

        [Column("E-mail")]
        [StringLength(64)]
        public string E_mail { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
