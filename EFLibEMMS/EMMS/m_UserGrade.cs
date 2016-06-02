namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_UserGrade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_UserGrade()
        {
            m_User = new HashSet<m_User>();
            m_UserAuthority = new HashSet<m_UserAuthority>();
            m_UserDataRelation = new HashSet<m_UserDataRelation>();
        }

        [Key]
        [StringLength(32)]
        public string UserGradeID { get; set; }

        [Required]
        [StringLength(8)]
        public string UserGrade { get; set; }

        public int Status { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_User> m_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_UserAuthority> m_UserAuthority { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_UserDataRelation> m_UserDataRelation { get; set; }
    }
}
