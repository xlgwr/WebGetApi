namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Message()
        {
            t_Recipient = new HashSet<t_Recipient>();
        }

        [Key]
        [StringLength(32)]
        public string MessageID { get; set; }

        [Required]
        [StringLength(32)]
        public string UserID { get; set; }

        [StringLength(64)]
        public string MessageTitle { get; set; }

        [StringLength(512)]
        public string Message { get; set; }

        public DateTime? SendTime { get; set; }

        public virtual m_User m_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Recipient> t_Recipient { get; set; }
    }
}
