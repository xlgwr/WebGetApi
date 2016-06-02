namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_User()
        {
            t_LogRecord = new HashSet<t_LogRecord>();
            t_Message = new HashSet<t_Message>();
        }

        [Key]
        [StringLength(32)]
        public string UserID { get; set; }

        [StringLength(32)]
        public string UserName { get; set; }

        [StringLength(32)]
        public string UserGradeID { get; set; }

        [StringLength(64)]
        public string Password { get; set; }

        [StringLength(32)]
        public string FullName_En { get; set; }

        [StringLength(32)]
        public string FullName_Cn { get; set; }

        [StringLength(32)]
        public string FullName_Tm { get; set; }

        [StringLength(32)]
        public string Tel { get; set; }

        [StringLength(32)]
        public string MobilePhone { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(32)]
        public string IDDocumentType { get; set; }

        [StringLength(32)]
        public string IDDocumentNo { get; set; }

        public int? Status { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_LogRecord> t_LogRecord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Message> t_Message { get; set; }

        public virtual m_UserGrade m_UserGrade { get; set; }
    }
}
