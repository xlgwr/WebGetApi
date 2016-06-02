namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_SysModuleDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_SysModuleDetail()
        {
            m_UserAuthority = new HashSet<m_UserAuthority>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(32)]
        public string Mod_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Opr_code { get; set; }

        public int? Sort { get; set; }

        public int? Status { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public virtual m_SysModule m_SysModule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_UserAuthority> m_UserAuthority { get; set; }
    }
}
