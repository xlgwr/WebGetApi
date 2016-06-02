namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_ContactPerson
    {
        [Key]
        [StringLength(32)]
        public string ContactPersonID { get; set; }

        [StringLength(32)]
        public string MemberComanyID { get; set; }

        [StringLength(16)]
        public string Surname { get; set; }

        [StringLength(16)]
        public string GivenNames { get; set; }

        [StringLength(8)]
        public string Salutation { get; set; }

        [StringLength(32)]
        public string FullName_Cn { get; set; }

        [StringLength(32)]
        public string FullName_Tm { get; set; }

        [StringLength(16)]
        public string Position { get; set; }

        [StringLength(16)]
        public string Department { get; set; }

        [StringLength(32)]
        public string OfficeTel1 { get; set; }

        [StringLength(32)]
        public string OfficeTel2 { get; set; }

        [StringLength(32)]
        public string MobilePhone { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(64)]
        public string PicPath1 { get; set; }

        public int? Default { get; set; }

        public virtual m_MemberComany m_MemberComany { get; set; }
    }
}
