namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_SetEmail
    {
        [Key]
        [StringLength(32)]
        public string SetEmailID { get; set; }

        [Required]
        [StringLength(32)]
        public string Host { get; set; }

        public DateTime Port { get; set; }

        [Required]
        [StringLength(64)]
        public string MailUsername { get; set; }

        [Required]
        [StringLength(128)]
        public string MailPassword { get; set; }

        public int? EnableSsl { get; set; }
    }
}
