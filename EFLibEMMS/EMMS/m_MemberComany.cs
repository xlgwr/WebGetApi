namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_MemberComany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_MemberComany()
        {
            m_ContactPerson = new HashSet<m_ContactPerson>();
            m_Member = new HashSet<m_Member>();
        }

        [Key]
        [StringLength(32)]
        public string MemberComanyID { get; set; }

        [StringLength(64)]
        public string FullName_En { get; set; }

        [StringLength(64)]
        public string FullName_Cn { get; set; }

        [StringLength(64)]
        public string FullName_Tm { get; set; }

        [Required]
        [StringLength(64)]
        public string BusinessType { get; set; }

        [Required]
        [StringLength(64)]
        public string CIBRNO { get; set; }

        [StringLength(8)]
        public string RoomNO { get; set; }

        [StringLength(8)]
        public string Floor { get; set; }

        [StringLength(64)]
        public string Street { get; set; }

        [StringLength(8)]
        public string StreetNumber { get; set; }

        [StringLength(16)]
        public string POBox { get; set; }

        [StringLength(16)]
        public string PostalCode { get; set; }

        [StringLength(16)]
        public string Area { get; set; }

        [StringLength(16)]
        public string City { get; set; }

        [StringLength(16)]
        public string Province { get; set; }

        [StringLength(32)]
        public string Country { get; set; }

        [StringLength(64)]
        public string PicPath1 { get; set; }

        [StringLength(64)]
        public string PicPath2 { get; set; }

        [StringLength(64)]
        public string PicPath3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_ContactPerson> m_ContactPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_Member> m_Member { get; set; }
    }
}
