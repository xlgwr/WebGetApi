namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_UserDataRelation
    {
        [Key]
        [StringLength(32)]
        public string RelationID { get; set; }

        [StringLength(32)]
        public string UserGradeID { get; set; }

        [StringLength(32)]
        public string DataGradeID { get; set; }

        public virtual m_DataGrade m_DataGrade { get; set; }

        public virtual m_UserGrade m_UserGrade { get; set; }
    }
}
