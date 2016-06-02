namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_MemberSetMealRelation
    {
        [Key]
        [StringLength(32)]
        public string RelationID { get; set; }

        [Required]
        [StringLength(32)]
        public string Type { get; set; }

        [StringLength(32)]
        public string Product { get; set; }

        [Required]
        [StringLength(32)]
        public string SetMealID { get; set; }

        [StringLength(32)]
        public string MemberGradeID { get; set; }

        [StringLength(32)]
        public string ProductID { get; set; }

        public virtual m_MemberGrade m_MemberGrade { get; set; }

        public virtual m_Product m_Product { get; set; }

        public virtual m_Package m_Package { get; set; }
    }
}
