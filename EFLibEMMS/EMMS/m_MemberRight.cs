namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_MemberRight
    {
        [Key]
        [StringLength(32)]
        public string MemberRightID { get; set; }

        public int Type { get; set; }

        [StringLength(32)]
        public string MemberID { get; set; }

        [StringLength(32)]
        public string MemberGradeID { get; set; }

        [StringLength(32)]
        public string RightKey { get; set; }

        public int? RightValue { get; set; }

        [StringLength(32)]
        public string LanguageCode { get; set; }

        [StringLength(32)]
        public string Remark { get; set; }

        public virtual m_Member m_Member { get; set; }

        public virtual m_MemberGrade m_MemberGrade { get; set; }

        public virtual m_RightKey m_RightKey { get; set; }
    }
}
