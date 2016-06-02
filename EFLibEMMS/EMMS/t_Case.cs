namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Case
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Case()
        {
            t_D_Representation = new HashSet<t_D_Representation>();
            t_Defendant = new HashSet<t_Defendant>();
            t_Judge = new HashSet<t_Judge>();
            t_Judgment = new HashSet<t_Judgment>();
            t_P_Representation = new HashSet<t_P_Representation>();
            t_Plaintiff = new HashSet<t_Plaintiff>();
            t_UpdateLog = new HashSet<t_UpdateLog>();
        }

        [Key]
        [StringLength(32)]
        public string Caseid { get; set; }

        [Required]
        [StringLength(32)]
        public string CaseNo { get; set; }

        [StringLength(32)]
        public string CaseNoNew { get; set; }

        [StringLength(32)]
        public string CaseNo_Cn { get; set; }

        [StringLength(16)]
        public string NumberTimes { get; set; }

        [Required]
        [StringLength(32)]
        public string CourtID { get; set; }

        [StringLength(32)]
        public string CaseTypeID { get; set; }

        [StringLength(8)]
        public string Year { get; set; }

        [StringLength(8)]
        public string SerialNo { get; set; }

        public DateTime? CourtDay { get; set; }

        [Column(TypeName = "text")]
        public string Plaintiff { get; set; }

        [Column(TypeName = "text")]
        public string Defendant { get; set; }

        [StringLength(256)]
        public string Cause { get; set; }

        [StringLength(256)]
        public string Nature { get; set; }

        [StringLength(256)]
        public string Judge { get; set; }

        [Column(TypeName = "text")]
        public string Representation { get; set; }

        [StringLength(256)]
        public string Hearing { get; set; }

        public DateTime? Actiondate { get; set; }

        [StringLength(16)]
        public string Currency { get; set; }

        public int? Amount { get; set; }

        public int? CheckField { get; set; }

        public int? Show { get; set; }

        [StringLength(32)]
        public string DataGradeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_D_Representation> t_D_Representation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Defendant> t_Defendant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Judge> t_Judge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Judgment> t_Judgment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_P_Representation> t_P_Representation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Plaintiff> t_Plaintiff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_UpdateLog> t_UpdateLog { get; set; }

        public virtual t_CaseType t_CaseType { get; set; }

        public virtual t_Court t_Court { get; set; }
    }
}
