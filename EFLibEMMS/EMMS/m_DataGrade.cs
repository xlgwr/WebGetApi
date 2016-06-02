namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_DataGrade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_DataGrade()
        {
            m_UserDataRelation = new HashSet<m_UserDataRelation>();
        }

        [Key]
        [StringLength(32)]
        public string DataGradeID { get; set; }

        [StringLength(8)]
        public string DataGrade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_UserDataRelation> m_UserDataRelation { get; set; }
    }
}
