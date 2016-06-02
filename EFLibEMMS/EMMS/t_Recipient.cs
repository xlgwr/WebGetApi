namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Recipient
    {
        [Key]
        [StringLength(32)]
        public string RecipientID { get; set; }

        [Required]
        [StringLength(32)]
        public string MemberID { get; set; }

        [Required]
        [StringLength(32)]
        public string MessageID { get; set; }

        public int? IsRead { get; set; }

        public virtual m_Member m_Member { get; set; }

        public virtual t_Message t_Message { get; set; }
    }
}
