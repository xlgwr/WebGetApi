namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_UserAuthority
    {
        [Key]
        [StringLength(32)]
        public string UserAuthorityID { get; set; }

        [Required]
        [StringLength(32)]
        public string UserGradeID { get; set; }

        [Required]
        [StringLength(32)]
        public string Mod_id { get; set; }

        public int Opr_code { get; set; }

        public virtual m_SysModuleDetail m_SysModuleDetail { get; set; }

        public virtual m_UserGrade m_UserGrade { get; set; }
    }
}
