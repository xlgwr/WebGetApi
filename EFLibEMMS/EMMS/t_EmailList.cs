namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_EmailList
    {
        [Key]
        [StringLength(32)]
        public string EmailID { get; set; }

        [Required]
        [StringLength(128)]
        public string Subject { get; set; }

        [Required]
        [StringLength(64)]
        public string FromMail { get; set; }

        [Required]
        [StringLength(128)]
        public string ToMail { get; set; }

        [Column(TypeName = "text")]
        public string EmailBody { get; set; }

        public DateTime ReceiveTime { get; set; }
    }
}
