namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_MemberGrade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_MemberGrade()
        {
            m_Member = new HashSet<m_Member>();
            m_MemberRight = new HashSet<m_MemberRight>();
            m_MemberSetMealRelation = new HashSet<m_MemberSetMealRelation>();
        }

        [Key]
        [StringLength(32)]
        public string MemberGradeID { get; set; }

        [Required]
        [StringLength(8)]
        public string MemberGrade { get; set; }

        [StringLength(128)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_Member> m_Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_MemberRight> m_MemberRight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_MemberSetMealRelation> m_MemberSetMealRelation { get; set; }
    }
}
