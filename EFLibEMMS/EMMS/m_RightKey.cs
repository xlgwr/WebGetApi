namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_RightKey
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_RightKey()
        {
            m_MemberRight = new HashSet<m_MemberRight>();
        }

        [Key]
        [StringLength(32)]
        public string RightKey { get; set; }

        [StringLength(32)]
        public string LanguageCode { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_MemberRight> m_MemberRight { get; set; }
    }
}
