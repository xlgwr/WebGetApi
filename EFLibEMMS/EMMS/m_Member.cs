namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public m_Member()
        {
            m_MemberRight = new HashSet<m_MemberRight>();
            t_ApplySouch = new HashSet<t_ApplySouch>();
            t_Payment = new HashSet<t_Payment>();
            t_Invoice = new HashSet<t_Invoice>();
            t_LogRecord = new HashSet<t_LogRecord>();
            t_Order = new HashSet<t_Order>();
            t_Quote = new HashSet<t_Quote>();
            t_Recipient = new HashSet<t_Recipient>();
        }

        [Key]
        [StringLength(32)]
        public string MemberID { get; set; }

        [StringLength(32)]
        public string MemberName { get; set; }

        [StringLength(32)]
        public string MemberGradeID { get; set; }

        [StringLength(64)]
        public string Password { get; set; }

        public double? RemainingSum { get; set; }

        [StringLength(8)]
        public string InvoiceDate { get; set; }

        public int? Type { get; set; }

        [StringLength(32)]
        public string MemberComanyID { get; set; }

        [Required]
        [StringLength(16)]
        public string Surname { get; set; }

        [Required]
        [StringLength(32)]
        public string GivenNames { get; set; }

        [Required]
        [StringLength(8)]
        public string Salutation { get; set; }

        [StringLength(32)]
        public string FullName_Cn { get; set; }

        [StringLength(32)]
        public string FullName_Tm { get; set; }

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

        [StringLength(32)]
        public string HomeTel { get; set; }

        [StringLength(32)]
        public string OfficeTel { get; set; }

        [StringLength(32)]
        public string MobilePhone { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        public int? Purpose1 { get; set; }

        public int? Purpose2 { get; set; }

        public int? Purpose3 { get; set; }

        public int? Purpose4 { get; set; }

        public int? Purpose5 { get; set; }

        public int? Purpose6 { get; set; }

        public int? Purpose7 { get; set; }

        public int? Pathway1 { get; set; }

        public int? Pathway2 { get; set; }

        public int? Pathway3 { get; set; }

        public int? Pathway4 { get; set; }

        public int? Pathway5 { get; set; }

        public int? Pathway6 { get; set; }

        [StringLength(64)]
        public string PicPath1 { get; set; }

        [StringLength(64)]
        public string PicPath2 { get; set; }

        [StringLength(64)]
        public string PicPath3 { get; set; }

        public int? PaymentWay { get; set; }

        public int? AcceptAgreement { get; set; }

        public int? EmailVerification { get; set; }

        public DateTime? LastSeachTime { get; set; }

        public int? Enable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_MemberRight> m_MemberRight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ApplySouch> t_ApplySouch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Payment> t_Payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Invoice> t_Invoice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_LogRecord> t_LogRecord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Order> t_Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Quote> t_Quote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Recipient> t_Recipient { get; set; }

        public virtual m_MemberComany m_MemberComany { get; set; }

        public virtual m_MemberGrade m_MemberGrade { get; set; }
    }
}
