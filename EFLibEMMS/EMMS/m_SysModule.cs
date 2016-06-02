namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_SysModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_SysModule()
        {
            m_SysModuleDetail = new HashSet<m_SysModuleDetail>();
        }

        [Key]
        [StringLength(32)]
        public string Mod_id { get; set; }

        [Required]
        [StringLength(32)]
        public string Mod_nm { get; set; }

        public int Parentid { get; set; }

        [Required]
        [StringLength(256)]
        public string Url { get; set; }

        public int? Iconic { get; set; }

        public int Sort { get; set; }

        public int? Islast { get; set; }

        [StringLength(32)]
        public string Version { get; set; }

        public int? Flag { get; set; }

        public int Status { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_SysModuleDetail> m_SysModuleDetail { get; set; }
    }
}
